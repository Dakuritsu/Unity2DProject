using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Player player;
    public List<Slot_UI> slots = new List<Slot_UI>();

    [SerializeField] private Canvas canvas;
    private Slot_UI draggedSlot;
    private Image draggedIcon;
    private bool dragSingle;
    
    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
        
        if(Input.GetKey(KeyCode.LeftAlt))
        {
            dragSingle = true;
        }
        else{
            dragSingle = false;
        }
    }

    public void ToggleInventory()   // Pour afficher l'inventaire
    {
        if(!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Refresh();
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
    }

    void Refresh()
    {
        if(slots.Count == player.inventory.slots.Count)
        {
            for (int i=0; i < slots.Count; i++)
            {
                if(player.inventory.slots[i].GetTypeSlot != CollectableType.NONE)
                {
                    slots[i].SetItem(player.inventory.slots[i]);
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
        Collectable itemToDrop = GameManager.instance.itemManager.GetItemByType(player.inventory.slots[draggedSlot.slotID].GetTypeSlot);

        if(itemToDrop != null)
        {
            if(dragSingle)
            {
                player.DropItem(itemToDrop);
                player.inventory.Remove(draggedSlot.slotID);
            }
            else
            {
                player.DropItem(itemToDrop , player.inventory.slots[draggedSlot.slotID].GetCount);
                player.inventory.Remove(draggedSlot.slotID , player.inventory.slots[draggedSlot.slotID].GetCount);
            }

            Refresh();
        }

        draggedSlot = null;

    }

    public void SlotBeginDrag(Slot_UI slot)
    {
        draggedSlot = slot;
        draggedIcon = Instantiate(draggedSlot.itemIcon);
        draggedIcon.transform.SetParent(canvas.transform);  // Pour en faire un enfant du canvas
        draggedIcon.raycastTarget = false;  // Pour que l'icone ne puisse pas bloquer les emplacements lorsqu'on drag
        draggedIcon.rectTransform.sizeDelta = new Vector2(50 , 50);

        MoveToMousePosition(draggedIcon.gameObject);
        Debug.Log("Start Drag: " + draggedSlot.name);
    }
    
    public void SlotDrag()
    {
        MoveToMousePosition(draggedIcon.gameObject);
        Debug.Log("Dragging : " + draggedSlot.name);
    }

    public void SlotEndDrag()
    {
        Destroy(draggedIcon.gameObject);
        draggedIcon = null;

        Debug.Log("Done Dragging: " + draggedSlot.name);
    }

    public void SlotDrop(Slot_UI slot)
    {
        Debug.Log("Dropped  " + draggedSlot.name + " on " + slot.name);
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
}
