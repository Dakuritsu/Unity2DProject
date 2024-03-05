using UnityEngine;
using UnityEngine.SceneManagement;

public enum PortalState
{
    Open,
    Closed,
    OnCooldown
}
public class HousePortal : MonoBehaviour
{
    public int SceneIndex;
    public Sprite OpenPortal;
    public Sprite ClosedPortal;
    public Sprite OnCooldownPortal;
    private bool Active;
    private float CooldownTime;


    private void Awake()
    { 
        Active = false;
        CooldownTime = 5.0f;
    }
    private void Start()
    {
        if (PortalData.State == PortalState.Open)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = OpenPortal;
        }
        else if (PortalData.State == PortalState.Closed)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = ClosedPortal;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = OnCooldownPortal;
        }
    }
    private void Update()
    {
        
            if (PortalData.State == PortalState.OnCooldown)
            {
                if (PortalData.OpenTime <= Time.time)
                {
                    PortalData.State = PortalState.Open;
                    gameObject.GetComponent<SpriteRenderer>().sprite = OpenPortal;
                }
            }

            if (Active)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (PortalData.State == PortalState.Open)
                    {
                        PortalData.State = PortalState.OnCooldown;
                        PortalData.OpenTime = Time.time + CooldownTime;
                        gameObject.GetComponent<SpriteRenderer>().sprite = OnCooldownPortal;
                        Teleport();
                    }
                }
                if (Input.GetKeyDown(KeyCode.C))
                {
                    if (PortalData.State == PortalState.Closed)
                    {
                        PortalData.State = PortalState.Open;
                        gameObject.GetComponent<SpriteRenderer>().sprite = OpenPortal;

                    } 
                    else if (PortalData.State == PortalState.Open)
                    {
                        PortalData.State = PortalState.Closed;
                        gameObject.GetComponent<SpriteRenderer>().sprite = ClosedPortal;

                    }
                }
            }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Active)
            {
                Active = false;
            }
        }
    }

    private void Teleport()
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

   private void LoadInteriorSceneAndTransferPlayer()
    {   
        // Charger la sc�ne concern�e 
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
