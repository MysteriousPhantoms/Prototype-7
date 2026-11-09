using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public InventoryItem currentItem;

    public Image slotImage;

    public Color normalColor = Color.white;
    public Color selectedColor = Color.yellow;

    public bool IsEmpty()
    {
        return currentItem == null;
    }

    public void Select()
    {
        if (slotImage != null)
            slotImage.color = selectedColor;
    }

    public void Deselect()
    {
        if (slotImage != null)
            slotImage.color = normalColor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        InventoryItem droppedItem =
            eventData.pointerDrag.GetComponent<InventoryItem>();

        if (droppedItem == null)
            return;

        InventorySlot oldSlot =
            droppedItem.parentAfterDrag.GetComponent<InventorySlot>();

        // MERGE STACKS
        if (currentItem != null)
        {
            if (currentItem.item == droppedItem.item &&
                currentItem.item.stackable)
            {
                currentItem.AddAmount(droppedItem.count);

                if (oldSlot != null)
                {
                    oldSlot.currentItem = null;
                }

                Destroy(droppedItem.gameObject);

                return;
            }

            return;
        }

        // NORMAL MOVE
        if (oldSlot != null)
        {
            oldSlot.currentItem = null;
        }

        currentItem = droppedItem;

        droppedItem.parentAfterDrag = transform;
    }
}
