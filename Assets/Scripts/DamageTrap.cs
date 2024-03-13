using UnityEngine;

public class DamageTrap : MonoBehaviour
{
    public float damage = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
 
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            
            Health playerHealth = player.GetComponent<Health>();

          
            if (playerHealth != null)
            {
                
                playerHealth.ReduceDamage(damage);
            }
        }
    }
}
