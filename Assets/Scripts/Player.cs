using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class Player : MonoBehaviour
{   
    private PlayerController playerController;
    public Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory(21);
    }

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void DropItem(Collectable item)
    {
        Vector2 spawnLocation = transform.position;
        Vector2 spawnOffset = Random.insideUnitCircle * 2f;

        Collectable dropppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);
        
        dropppedItem.rb2d.AddForce(spawnOffset * 2f , ForceMode2D.Impulse);//ForceMode2D.Impulse pour que la force ne s'applique pas au fil du temps
    }
    
}
