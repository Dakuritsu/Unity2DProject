using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Pour savoir quel Prefab est associés à quel type
public class ItemManager : MonoBehaviour
{
    public Collectable[] collectableItems; // Tableau de tout les collectables
    private Dictionary<CollectableType, Collectable> collectableItemsDict = new Dictionary<CollectableType, Collectable>();

    private void Awake()    // On remplit le dictionnaire 
    {
        foreach (Collectable item in collectableItems)
        {
            AddItem(item);
        }
    }
    private void AddItem(Collectable item)  // Ajoute un Collectable au dictionnaire si il n'y est pas déjà
    {
        if(!collectableItemsDict.ContainsKey(item.GetTypeCollectable))
        {
            collectableItemsDict.Add(item.GetTypeCollectable,item);
        }
    }

    public Collectable GetItemByType(CollectableType type)  // Récupère le Collectable associés au type spécifié
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
