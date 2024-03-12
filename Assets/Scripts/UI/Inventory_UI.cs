using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    
    public string inventoryName;
    public List<Slot_UI> slots = new List<Slot_UI>();

    private bool dragSingle;
    private Inventory inventory;
    
    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
    }

    private void Start()
    {
        inventory = GameManager.instance.player.inventory.GetInventoryByName(inventoryName);

        SetupSlots();
        Refresh();
    }

    public void Refresh()
    {
        if(slots.Count == inventory.slots.Count)
        {
            for (int i=0; i < slots.Count; i++)
            {
                if(inventory.slots[i].GetTypeSlot != CollectableType.NONE)
                {
                    slots[i].SetItem(inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }

    public void Remove()
    {
        Collectable itemToDrop = GameManager.instance.itemManager.GetItemByType(inventory.slots[UI_Manager.draggedSlot.slotID].GetTypeSlot);

        if(itemToDrop != null)
        {
            if(UI_Manager.dragSingle)
            {
                GameManager.instance.player.DropItem(itemToDrop);
                inventory.Remove(UI_Manager.draggedSlot.slotID);
            }
            else
            {
                GameManager.instance.player.DropItem(itemToDrop , inventory.slots[UI_Manager.draggedSlot.slotID].GetCount);
                inventory.Remove(UI_Manager.draggedSlot.slotID , inventory.slots[UI_Manager.draggedSlot.slotID].GetCount);
            }

            Refresh();
        }

        UI_Manager.draggedSlot = null;

    }

    public void SlotBeginDrag(Slot_UI slot)
    {   
        UI_Manager.draggedSlot = slot;
        UI_Manager.draggedIcon = Instantiate(slot.itemIcon);
        UI_Manager.draggedIcon.transform.SetParent(canvas.transform);  // Pour en faire un enfant du canvas
        UI_Manager.draggedIcon.raycastTarget = false;  // Pour que l'icone ne puisse pas bloquer les emplacements lorsqu'on drag
        UI_Manager.draggedIcon.rectTransform.sizeDelta = new Vector2(50 , 50);

        MoveToMousePosition(UI_Manager.draggedIcon.gameObject);
    }
    
    public void SlotDrag()
    {
        MoveToMousePosition(UI_Manager.draggedIcon.gameObject);
    }

    public void SlotEndDrag()
    {
        Destroy(UI_Manager.draggedIcon.gameObject);
        UI_Manager.draggedIcon = null;
    }

    public void SlotDrop(Slot_UI slot)
    {
        if(UI_Manager.dragSingle)
        {
            UI_Manager.draggedSlot.inventory.MoveSlot(UI_Manager.draggedSlot.slotID , slot.slotID , slot.inventory);
        }
        else
        {
            UI_Manager.draggedSlot.inventory.MoveSlot(UI_Manager.draggedSlot.slotID , slot.slotID , slot.inventory, UI_Manager.draggedSlot.inventory.slots[UI_Manager.draggedSlot.slotID].GetCount);
        }
        GameManager.instance.uiManager.RefreshAll();
    }

    private void MoveToMousePosition(GameObject toMove)
    {
        if(canvas != null)
        {
            Vector2 position;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform , Input.mousePosition, null, out position);

            toMove.transform.position = canvas.transform.TransformPoint(position);
        }
    }

    void SetupSlots()
    {
        int counter = 0;

        foreach(Slot_UI slot in slots)
        {
            slot.slotID = counter;
            counter++;
            slot.inventory = inventory;
        }
    }
}
