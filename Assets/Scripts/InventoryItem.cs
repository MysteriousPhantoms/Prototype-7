using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InventoryItem : MonoBehaviour,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler
{
    public Image image;

    [HideInInspector]
    public ItemData item;

    [HideInInspector]
    public Transform parentAfterDrag;

    public void InitialiseItem(ItemData newItem)
    {
        item = newItem;

        image.sprite = item.icon;
    }

    public void OnBeginDrag(
        PointerEventData eventData)
    {
        image.raycastTarget = false;

        parentAfterDrag = transform.parent;

        transform.SetParent(transform.root);
    }

    public void OnDrag(
        PointerEventData eventData)
    {
        transform.position =
            Mouse.current.position.ReadValue();
    }

    public void OnEndDrag(
        PointerEventData eventData)
    {
        image.raycastTarget = true;

        transform.SetParent(parentAfterDrag);
    }
}
