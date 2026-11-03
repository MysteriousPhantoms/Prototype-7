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

        if (count > 1)
        {
            countText.text = count.ToString();
        }
        else
        {
            countText.text = "";
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ToolManager.Instance.SelectTool(item);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;

        parentAfterDrag = transform.parent;

        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position =
            Mouse.current.position.ReadValue();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;

        transform.SetParent(parentAfterDrag);
    }
}
