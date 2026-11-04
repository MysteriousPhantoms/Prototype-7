using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InventoryItem :
    MonoBehaviour,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler,
    IPointerClickHandler
{
    public Image image;
    public TextMeshProUGUI countText;

    [HideInInspector]
    public ItemData item;

    [HideInInspector]
    public int count = 1;

    [HideInInspector]
    public Transform parentAfterDrag;

    private Transform originalParent;

    private bool dragging;

    public void InitialiseItem(ItemData newItem)
    {
        item = newItem;

        image.sprite = item.icon;

        RefreshCount();
    }

    public void AddAmount(int amount)
    {
        count += amount;

        RefreshCount();
    }

    public void RefreshCount()
    {
        if (countText == null)
            return;

        countText.text =
            count > 1
                ? count.ToString()
                : "";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (dragging)
            return;

        InventorySlot slot =
            GetComponentInParent<InventorySlot>();

        ToolManager.Instance.SelectTool(item, slot);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragging = true;

        image.raycastTarget = false;

        originalParent = transform.parent;

        parentAfterDrag = originalParent;

        transform.SetParent(
            GetComponentInParent<Canvas>().transform
        );
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position =
            Mouse.current.position.ReadValue();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragging = false;

        image.raycastTarget = true;

        transform.SetParent(parentAfterDrag);

        transform.localPosition = Vector3.zero;
    }
}
