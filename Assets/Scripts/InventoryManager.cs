using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public InventorySlot[] toolbarSlots;

    public InventoryItem inventoryItemPrefab;

    public void AddItem(ItemData item)
    {
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

    private void SpawnNewItem(
        ItemData item,
        InventorySlot slot)
    {
        InventoryItem newItem =
            Instantiate(
                inventoryItemPrefab,
                slot.transform);

        newItem.InitialiseItem(item);

        slot.currentItem = newItem;
    }
    
    public ItemData testItem;

    private void Start()
    {
        AddItem(testItem);
    }
    
}
