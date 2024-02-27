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
        healthBarImage = GetComponent<Image>(); //obtient le composant Image attach� � cet objet
    }

    private void Update()
    {
        if (playerHealth != null)
        {
            //met � jour la taille de la barre de vie en fonction de la sant� actuelle du joueur
            //float fillAmount = playerHealth.GetCurrentHealth / playerHealth.GetMaxHealth;
            //healthBarImage.fillAmount = fillAmount;
        }
    }
}
