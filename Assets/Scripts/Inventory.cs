using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot   
    {
        public CollectableType type;
        public int count;
        public int maxAllowed;
        public Sprite icon;
        public Slot()   // Constructeur Slot 
        {
            type = CollectableType.NONE;
            count = 0;
            // maxAllowed = 60;
        }

        public bool CanAddItem()    // vérifie si il y a encore de la place
        {
            if(count < maxAllowed)
            {
                return true;
            }

            return false;
        }

        public void AddItem(Collectable item) //modifie le type et l'icon du slot
        {
            this.type = item.type;
            this.icon = item.icon;
            this.maxAllowed = item.maxAllowed;
            count++;
        }
        
    }

    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots)  // Constructeur Inventory initialise chaque case 
    {
        for(int i=0 ; i < numSlots ; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    } 

    public void Add(Collectable item)// ajoute le collectable si on peut
    {
        foreach(Slot slot in slots)
        {
            if(slot.type  == item.type && slot.CanAddItem())
            {
                slot.AddItem(item);
                return;
            }
        }

        foreach(Slot slot in slots)
        {
            if(slot.type == CollectableType.NONE)
            {
                slot.AddItem(item);
                return;
            }
        }
    }
}
