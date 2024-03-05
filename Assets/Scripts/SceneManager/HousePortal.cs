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
        // Charger la sc�ne consern�e 
        SceneManager.LoadScene(SceneIndex, LoadSceneMode.Single);
        // R�cup�rer une r�f�rence au joueur
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {   // Si le joueur existe dans la nouvelle sc�ne, on pr�cise juste sa position
            player.transform.position = new Vector3(-4f, -2f);
        }
        else
        {   // Sinon on r�cup�re une r�f�rence au joueur dans la sc�ne d'origine
            GameObject playerInPreviousScene = GameObject.FindGameObjectWithTag("Player");

            if (playerInPreviousScene != null)
            {
                // Instancier le joueur dans la nouvelle sc�ne
                player = Instantiate(playerInPreviousScene);

                //On d�place le joueur dans la nouvelle sc�ne 
                SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByBuildIndex(SceneIndex));

                // On D�finit la nouvelle position du joueur 
                player.transform.position = new Vector3(-4f, -2f);

                // On �vite que le joueur ne soit d�truit lorsque la sv�ne est chang�e 
                DontDestroyOnLoad(player);
            }
            else
            {
                Debug.LogWarning("Player not found in the previous scene.");
            }
        }
    }

}
