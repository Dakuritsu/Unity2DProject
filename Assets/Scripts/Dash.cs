using UnityEngine;
using UnityEngine.Events;   
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Dash : MonoBehaviour
{
    private bool canDash = true;
    private bool isDashing;
    private Vector2 dashingDir;
    private Endurance endurance;
    private Rigidbody2D rb;
 
    [SerializeField] private int dashingCost = 30;
    [SerializeField] private float dashingPower = 28f;
    [SerializeField] private float dashingTime = 0.5f;
    [SerializeField] private float dashTimer = 0f;
    [SerializeField] private TrailRenderer tr;

    [SerializeField] private UnityEvent DashCompleted;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        endurance = GetComponent<Endurance>();
    }



    private void Update()
    {
        if (isDashing)
        {
            dashTimer += Time.deltaTime;
            if (dashTimer >= dashingTime)
            {
                StopDashing();
            }
            else
            {
                dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                if (dashingDir == Vector2.zero)
                {
                    dashingDir = new Vector2(transform.localScale.x, 0f);
                }

                rb.velocity = dashingDir.normalized * dashingPower;
            }
        }
    }

    public bool TryDash()
    {
        if (canDash && endurance.GetCurrentEndurance >= dashingCost)
        {
            endurance.ConsumeEnduranceForDash(dashingCost);
            isDashing = true;
            canDash = false;
            tr.emitting = true;
            dashTimer = 0f;

            return true;
        }

        return false;
    }

    private void StopDashing()
    {
        rb.velocity = Vector2.zero;
        tr.emitting = false;
        isDashing = false;
        canDash = true;
        DashCompleted.Invoke();
    }
}
