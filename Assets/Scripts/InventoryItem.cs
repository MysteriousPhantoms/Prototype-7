using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InventoryItem : MonoBehaviour,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler
{
    [Header("UI")]
    public Image image;

    [HideInInspector]
    public Transform parentAfterDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;

        parentAfterDrag = transform.parent;

        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Mouse.current.position.ReadValue();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;

        transform.SetParent(parentAfterDrag);
    }
}
