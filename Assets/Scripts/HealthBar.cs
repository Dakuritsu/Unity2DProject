using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Health playerHealth;
    private Image healthBarImage;

    private void Start()
    {
        healthBarImage = GetComponent<Image>(); //composant Image attaché à cet objet

        //vérifie si le script Health est attaché au joueur
        if (playerHealth != null)
        {
            // Abonne la méthode UpdateHealthBar à l'événement OnHealthChanged
            playerHealth.OnHealthChanged += UpdateHealthBar;
        }
        else
        {
            Debug.LogWarning("Aucun script 'Health' n'a été trouvé sur le joueur.");
        }
    }

    //met à jour la barre de vie en fonction de la santé actuelle du joueur
    private void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        float fillAmount = currentHealth / maxHealth;
        healthBarImage.fillAmount = fillAmount;
    }

    // Se désabonne de l'événement lors de la désactivation du script
    private void OnDisable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= UpdateHealthBar;
        }
    }
}

