using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HousePortal : MonoBehaviour
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
        // Charger la scène consernée 
        SceneManager.LoadScene(SceneIndex, LoadSceneMode.Single);
        // Récupérer une référence au joueur
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {   // Si le joueur existe dans la nouvelle scène, on précise juste sa position
            player.transform.position = new Vector3(-4f, -2f);
        }
        else
        {   // Sinon on récupére une référence au joueur dans la scène d'origine
            GameObject playerInPreviousScene = GameObject.FindGameObjectWithTag("Player");

            if (playerInPreviousScene != null)
            {
                // Instancier le joueur dans la nouvelle scène
                player = Instantiate(playerInPreviousScene);

                //On déplace le joueur dans la nouvelle scène 
                SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByBuildIndex(SceneIndex));

                // On Définit la nouvelle position du joueur 
                player.transform.position = new Vector3(-4f, -2f);

                // On évite que le joueur ne soit détruit lorsque la svène est changée 
                DontDestroyOnLoad(player);
            }
            else
            {
                Debug.LogWarning("Player not found in the previous scene.");
            }
        }
    }

}
