using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Collectable[] collectableItems;
    private Dictionary<CollectableType, Collectable> collectableItemsDict = new Dictionary<CollectableType, Collectable>();

    private void Awake()
    {
        foreach (Collectable item in collectableItems)
        {
            AddItem(item);
        }
    }
    private void AddItem(Collectable item)
    {
        if(!collectableItemsDict.ContainsKey(item.GetTypeCollectable))
        {
            collectableItemsDict.Add(item.GetTypeCollectable,item);
        }
    }

    public Collectable GetItemByType(CollectableType type)
    {
        if(collectableItemsDict.ContainsKey(type))
        {
            return collectableItemsDict[type];
        }
        else{
            return null;
        }
    }
}
