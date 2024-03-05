using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrap : MonoBehaviour
{
    
    public float damageAmount = 15f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //v�rifie si le pi�ge entre en collision avec le joueur
        {
            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.ReduceDamage(damageAmount);
            }
        }
    }
}

