using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public InventorySlot[] inventorySlots;
    public InventorySlot[] toolbarSlots;

    public InventoryItem inventoryItemPrefab;

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(ItemData item)
    {
        if (item == null)
            return;

        // Stack items first
        if (item.stackable)
        {
            InventoryItem existingItem = FindStack(item);

            if (existingItem != null)
            {
                existingItem.AddAmount(1);
                return;
            }
        }

        // Tools go to toolbar
        if (item.itemType == ItemType.Tool)
        {
            foreach (InventorySlot slot in toolbarSlots)
            {
                if (slot.IsEmpty())
                {
                    SpawnNewItem(item, slot);
                    return;
                }
            }

            Debug.Log("Toolbar Full");
            return;
        }

        // Resources and quest items go to inventory
        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.IsEmpty())
            {
                SpawnNewItem(item, slot);
                return;
            }
        }

        Debug.Log("Inventory Full");
    }

    private InventoryItem FindStack(ItemData item)
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            if (!slot.IsEmpty())
            {
                if (slot.currentItem.item == item)
                {
                    return slot.currentItem;
                }
            }
        }

        return null;
    }

    private void SpawnNewItem(ItemData item, InventorySlot slot)
    {
        InventoryItem newItem =
            Instantiate(
                inventoryItemPrefab,
                slot.transform);

        newItem.InitialiseItem(item);

        slot.currentItem = newItem;
    }
}
