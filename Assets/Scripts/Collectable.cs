using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableType type;
    public Sprite icon;
    public int maxAllowed;
    private void OnTriggerEnter2D(Collider2D collision){
        Player player = collision.GetComponent<Player>();

        if(player)
        {
            player.inventory.Add(this);
            Destroy(this.gameObject);
        }
    }
}

public enum CollectableType // enum avec les différent types 
{
    NONE, 
    GOLD
}
