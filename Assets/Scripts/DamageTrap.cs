using UnityEngine;

public class DamageTrap : MonoBehaviour
{
    // Dommage inflig� � chaque collision avec la zone de pi�ge
    public float dommage = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // V�rifie si l'objet en collision est le joueur
        if (other.CompareTag("Player"))
        {
            // R�cup�re le script de sant� du joueur
            Health playerHealth = other.GetComponent<Health>();

            // V�rifie si le script de sant� existe sur le joueur
            if (playerHealth != null)
            {
                // Applique les dommages au joueur en utilisant la fonction ReduceDamage du script de sant�
                playerHealth.ReduceDamage(dommage);
            }
        }
    }
}

