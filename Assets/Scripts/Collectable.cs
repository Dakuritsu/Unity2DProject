using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private CollectableType type;
    [SerializeField] private Sprite icon;
    [SerializeField] private int maxAllowed;

    public Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();    
    }
//------------------------ GET --------------------------------
    public CollectableType GetTypeCollectable
    {
        get { return type; }
    }
    public Sprite GetIcon
    {
        get { return icon; }
    }
    public int GetMaxAllowed
    {
        get { return maxAllowed; }
    }

//================================================================

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
