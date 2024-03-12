using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Health playerHealth;
    private Image healthBarImage;

    private void Start()
    {
        healthBarImage = GetComponent<Image>(); //composant Image attach� � cet objet

        //v�rifie si le script Health est attach� au joueur
        if (playerHealth != null)
        {
            // Abonne la m�thode UpdateHealthBar � l'�v�nement OnHealthChanged
            playerHealth.OnHealthChanged += UpdateHealthBar;
        }
        else
        {
            Debug.LogWarning("Aucun script 'Health' n'a �t� trouv� sur le joueur.");
        }
    }

    //met � jour la barre de vie en fonction de la sant� actuelle du joueur
    private void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        float fillAmount = currentHealth / maxHealth;
        healthBarImage.fillAmount = fillAmount;
    }

    // Se d�sabonne de l'�v�nement lors de la d�sactivation du script
    private void OnDisable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= UpdateHealthBar;
        }
    }
}

