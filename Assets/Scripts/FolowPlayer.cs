using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // Référence au transform du joueur
    public float offsetY = 1.0f; // Décalage en hauteur pour la barre de vie

    void Update()
    {
        if (player != null)
        {
            Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(player.position); //mettre à jour la position de la barre de vie pour qu'elle soit au-dessus du joueur
            transform.position = playerScreenPosition + Vector3.up * offsetY; //ajuster la hauteur
        }
    }
}



