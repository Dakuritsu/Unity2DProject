using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public int SceneIndex;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (SceneIndex == 2)// Si on veut charger la scene "Base"
            {
                LoadInteriorSceneAndTransferPlayer();
            }
            else// Sinon on charge la scene normalement
            {
                SceneManager.LoadScene(SceneIndex, LoadSceneMode.Single);
            }
        }
    }

    private void LoadInteriorSceneAndTransferPlayer()
    {
        // Charger la scène intérieure
        SceneManager.LoadScene(SceneIndex, LoadSceneMode.Single);

        // Récupérer une référence au joueur
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Déplacer le joueur dans la nouvelle scène
            SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByBuildIndex(SceneIndex));

            // Éviter que le joueur ne soit détruit lorsque la scène est changée
            DontDestroyOnLoad(player);

            // Définir la nouvelle position du joueur
            //player.transform.position = new Vector3(-2.5f, -2.5f);
        }
        else
        {
            Debug.LogWarning("Player not found");
        }
    }

}
