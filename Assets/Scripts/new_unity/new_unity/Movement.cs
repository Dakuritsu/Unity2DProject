using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public Animator animator;
    private Endurance endurance;    


    private void Start()
    {
        endurance = GetComponent<Endurance>();
    }

    private void Update(){
        float horizontal = Input.GetAxisRaw("Horizontal"); // Q D -> <-
        float vertical = Input.GetAxisRaw("Vertical"); // Z S flèche du haut flèche du bas

        Vector3 direction = new Vector3(horizontal, vertical);

        AnimateMovement(direction);

        transform.position += direction * GetSpeed() * Time.deltaTime;
    }

    private float GetSpeed()
    {
        return Input.GetKey(KeyCode.LeftShift) && endurance.currentEndurance > 0 ? speed * 2f : speed;
    }

    void AnimateMovement(Vector3 direction){
        if(animator != null)
        {
            if(direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);

                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }

    }
}