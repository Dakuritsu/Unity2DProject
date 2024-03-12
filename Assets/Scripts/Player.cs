using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]

public class Player : MonoBehaviour
{   
    private PlayerController playerController;
    public InventoryManager inventory;

    private void Awake()
    {
        inventory = GetComponent<InventoryManager>();
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

    public void DropItem(Collectable item , int numToDrop)
    {
        for(int i=0 ; i < numToDrop ; i++)
        {
            DropItem(item);
        }
    }
}
