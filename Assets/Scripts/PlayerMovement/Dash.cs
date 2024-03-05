using UnityEngine;
using UnityEngine.Events;   
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Dash : MonoBehaviour
{
    private Collider2D playerCollider;
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
        playerCollider = GetComponent<Collider2D>();
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
            Vector2 finalPosition = (Vector2)transform.position + rb.velocity.normalized * dashingPower * dashingTime;
            //OverlapBoxAll => liste de tous les colliders qui se trouvent à l'intérieur d'une zone définie.
            /*
                finalPosition -> la position de la zone 
                playerCollider.bounds.size -> sa taille

            */
            Collider2D[] colliders = Physics2D.OverlapBoxAll(finalPosition, playerCollider.bounds.size, 0f);
            bool collided = false;
            foreach (Collider2D collider in colliders)
            {
                if (collider != playerCollider)
                {
                    collided = true;
                    break;
                }
            }

            if (!collided)
            {
                playerCollider.enabled = false;
            }

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
        playerCollider.enabled = true;

        rb.velocity = Vector2.zero;
        tr.emitting = false;
        isDashing = false;
        canDash = true;
        DashCompleted.Invoke();
    }
}
