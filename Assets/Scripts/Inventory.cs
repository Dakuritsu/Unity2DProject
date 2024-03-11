using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot   
    {
        [SerializeField] private CollectableType type;
        [SerializeField] private int count;
        [SerializeField] private int maxAllowed;
        [SerializeField] private Sprite icon;

        
        public Slot()   // Constructeur Slot 
        {
            type = CollectableType.NONE;
            count = 0;
        }


        //---------------- GET ------------------
        public CollectableType GetTypeSlot
        {
            get { return type; }
        }
        public int GetCount
        {
            get { return count; }
        }
        public int GetMaxAllowed
        {
            get { return maxAllowed; }
        }
        public Sprite GetIcon
        {
            get { return icon; }
        }

        //=====================================================

        public bool CanAddItem()    // Vérifie si il y a encore de la place
        {
            if(count < maxAllowed)
            {
                return true;
            }

            return false;
        }

        public void AddItem(Collectable item)   // Modifie le type et l'icon du slot
        {
            this.type = item.GetTypeCollectable;
            this.icon = item.GetIcon;
            this.maxAllowed = item.GetMaxAllowed;
            count++;
        }

        public void RemoveItem()    // Retire 1 à la quantité du slot
        {
            if(count > 0)
            {
                count--;

                if(count == 0)
                {
                    icon = null;
                    type = CollectableType.NONE;
                }
            }
        }
        
    }

    //========= Suite de la classe Inventory ==================

    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots)  // Constructeur Inventory initialise chaque case 
    {
        for(int i=0 ; i < numSlots ; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    } 

    public void Add(Collectable item)   // Ajoute le collectable si on peut
    {
        foreach(Slot slot in slots)
        {
            if(slot.GetTypeSlot  == item.GetTypeCollectable && slot.CanAddItem())
            {
                slot.AddItem(item);
                return;
            }
        }

        foreach(Slot slot in slots)
        {
            if(slot.GetTypeSlot == CollectableType.NONE)
            {
                slot.AddItem(item);
                return;
            }
        }
    }

    public void Remove(int index)   // Appelle RemoveItem sur un index choisi
    {
        slots[index].RemoveItem();
    }

    public void Remove(int index , int numToRemove)   // Appelle RemoveItem sur un index choisi
    {
        if(slots[index].GetCount >= numToRemove)
        {
            for(int i=0 ; i < numToRemove ; i++)
            {
                Remove(index);
            }
        }
    }
}
