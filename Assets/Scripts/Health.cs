using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void ReduceDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        Debug.Log("Dommages du joueur " + damageAmount + " Current health: " + currentHealth);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died.");
        //gameObject.SetActive(false);
    }

    public float GetCurrentHealth()
    {
        
        return this.currentHealth;
    }


    public float GetMaxHealth()
    {
        return this.maxHealth;
    }



}
