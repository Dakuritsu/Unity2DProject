using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    // D�finir un �v�nement pour signaler les changements de sant� du joueur
    public delegate void HealthChanged(float currentHealth, float maxHealth);
    public event HealthChanged OnHealthChanged;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void ReduceDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        Debug.Log("Dommages du joueur " + damageAmount + " Current health: " + currentHealth);

        // D�clencher l'�v�nement de changement de sant�
        if (OnHealthChanged != null)
            OnHealthChanged(currentHealth, maxHealth);

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

