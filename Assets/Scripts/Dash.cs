using UnityEngine;
using System.Collections;

public class Dash : MonoBehaviour
{
    private bool canDash = true;
    private bool isDashing;
    private Vector2 dashingDir;
    private Endurance endurance;

    [SerializeField] private float dashingPower = 28f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TrailRenderer tr;


    private void Start()
    {
        endurance = GetComponent<Endurance>();
    }
    
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && canDash && endurance.GetCurrentEndurance >= 30f)
        {
            isDashing = true;
            canDash = false;
            tr.emitting = true;
            dashingDir = new Vector2(Input.GetAxisRaw("Horizontal") , Input.GetAxisRaw("Vertical"));

            if(dashingDir == Vector2.zero)
            {
                dashingDir = new Vector2(transform.localScale.x, 0f);
            }
            StartCoroutine(StopDashing());
            endurance.ConsumeEnduranceForDash(30f);
        }
        
        if(isDashing)
        {
            rb.velocity = dashingDir.normalized * dashingPower;
            return;
        }
    }

    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(dashingTime);
        rb.velocity = Vector2.zero;
        tr.emitting = false;
        isDashing = false;
        canDash = true;
    }
}
