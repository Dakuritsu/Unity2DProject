using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Health playerHealth; 

    private Image healthBarImage;

    private void Start()
    {
        healthBarImage = GetComponent<Image>(); //obtient le composant Image attaché à cet objet
    }

    private void Update()
    {
        if (playerHealth != null)
        {
            //met à jour la taille de la barre de vie en fonction de la santé actuelle du joueur
            //float fillAmount = playerHealth.GetCurrentHealth / playerHealth.GetMaxHealth;
            //healthBarImage.fillAmount = fillAmount;
        }
    }
}
