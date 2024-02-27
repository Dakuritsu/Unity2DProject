using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Endurance))]
[RequireComponent(typeof(Dash))]


public class PlayerController : MonoBehaviour
{
    private Movement movement;
    private Endurance endurance;
    private Dash dash;

    private int states = 0; // 0 -> Walk Sprint
                            // 1 -> Dash

    private void Start()
    {
        movement = GetComponent<Movement>();
        dash = GetComponent<Dash>();
        endurance = GetComponent<Endurance>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        

        Debug.Log("quantité d'endurance :" + endurance.GetCurrentEndurance + "\n");
  
        if(states == 0){//Si on peut se déplacer
            //si on veut se Déplacer
            movement.SetDirection(new Vector3(horizontal, vertical, 0));

            //Si on veut Sprint
            if(Input.GetKey(KeyCode.LeftShift))
            {
                movement.TrySprint();
            }
        }
        //Si on veux Dash
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("L'état actuel est : " + states);
            if(dash.TryDash())
            {
                movement.SetDirection(new Vector3(0, 0, 0));
            }
        }
        
        if (endurance.GetCurrentEndurance < endurance.GetMaxEndurance)
        {
            endurance.recoveryEndurance();
        }
    }

    public void SetState(int state)
    {
        states = state;
    }
}
