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
        Debug.Log("DROP WORKED ON: " + gameObject.name);

        InventoryItem droppedItem =
            eventData.pointerDrag.GetComponent<InventoryItem>();

        if (droppedItem == null)
            return;

        droppedItem.parentAfterDrag = transform;
    }
}
