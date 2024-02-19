using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement : MonoBehaviour
{
    private Vector3 direction; // car sinon on peut pas l'utiliser dans FixedUpdate()
    private Endurance endurance;

    [SerializeField] private float speed;
    [SerializeField] private Animator animator;


    private void Start()
    {
        endurance = GetComponent<Endurance>();
    }

    private void Update(){
        float horizontal = Input.GetAxisRaw("Horizontal"); // Q D -> <-
        float vertical = Input.GetAxisRaw("Vertical"); // Z S flèche du haut flèche du bas

        direction = new Vector3(horizontal, vertical, 0);

        AnimateMovement(direction);
    }

    //LateUpdate appelé avant que les collisions ne soient calculées donc on choisit FixedUpdate()
    private void FixedUpdate(){
        transform.position += direction.normalized * GetSpeed() * Time.deltaTime;
    }

    private float GetSpeed()
    {
        return Input.GetKey(KeyCode.LeftShift) && endurance.GetCurrentEndurance > 0 ? speed * 2f : speed;
    }

    private void AnimateMovement(Vector3 direction){
        if(animator != null)
        {
            if(direction.magnitude > 0)// Pour savoir si le personnage se déplace
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
