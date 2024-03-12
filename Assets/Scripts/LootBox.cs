using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour
{
    [SerializeField] private GameObject dropItem;
    [SerializeField] private int itemNum = 2;
    [SerializeField] private KeyCode lootKey = KeyCode.F;
    private bool Active;
    

    // Update is called once per frame
    void Update()
    {
        if (Active) {
            if (Input.GetKeyDown(lootKey)) 
            {
                InstantiateLoot();
            }
        }
    }

    private void InstantiateLoot()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            
            for (int i = 0;i < itemNum;i++) 
            {

                float max = 2f;
                float min = -2f;

                float randX = Random.Range(min,max);
                float randY = Random.Range(min,max);

                Vector3 spawnOffset = new Vector3(randX,randY,0f);
                Vector3 spawnPosition = transform.position + spawnOffset;
                Instantiate(dropItem,spawnPosition,Quaternion.identity);
            }
            Destroy(this.gameObject);
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
}
