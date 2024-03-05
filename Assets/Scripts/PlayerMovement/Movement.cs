using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Endurance))]
public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Endurance endurance;
    private Vector3 direction;
    
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;

    public Animator GetAnimator
    {
        get { return animator; }
    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection;
        if (animator != null)
        {
            if (direction.magnitude > 0.5) // Pour savoir si le personnage se déplace
            {
                rb.velocity = direction * speed;
                animator.SetBool("isMoving", true);

                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);
            }
            else
            {
                rb.velocity = Vector3.zero;
                animator.SetBool("isMoving", false);
            }
        }
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        endurance = GetComponent<Endurance>();
    }

    private void Update()
    {
        
    }


    private float GetSpeed()
    {
        return endurance.GetCurrentEndurance >= endurance.GetEnduranceConsumptionRate ? (speed * 2f) : speed;
    }



    public void TrySprint()
    {
        if (direction.magnitude > 0)
        {
            if(endurance.GetCurrentEndurance >= endurance.GetEnduranceConsumptionRate)
            {
                rb.velocity = direction.normalized * (speed * 2f);
                endurance.ConsumeEndurance();  
            }
        }      
    }

}
