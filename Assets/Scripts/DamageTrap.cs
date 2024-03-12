using UnityEngine;

public class DamageTrap : MonoBehaviour
{
    // Dommage infligé à chaque collision avec la zone de piège
    public float dommage = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifie si l'objet en collision est le joueur
        if (other.CompareTag("Player"))
        {
            // Récupère le script de santé du joueur
            Health playerHealth = other.GetComponent<Health>();

            // Vérifie si le script de santé existe sur le joueur
            if (playerHealth != null)
            {
                // Applique les dommages au joueur en utilisant la fonction ReduceDamage du script de santé
                playerHealth.ReduceDamage(dommage);
            }
        }
    }
}

