using UnityEngine;

public class ChestLoader : MonoBehaviour
{
    public ChestData chestData;

    public InventorySlot[] chestSlots;

    public InventoryItem itemPrefab;

    private void Start()
    {
        if (chestData == null)
            return;

        for (int i = 0;
             i < chestData.items.Length &&
             i < chestSlots.Length;
             i++)
        {
            ItemData item =
                chestData.items[i];

            if (item == null)
                continue;

            InventoryItem newItem =
                Instantiate(
                    itemPrefab,
                    chestSlots[i].transform);

            newItem.InitialiseItem(item);

            if (chestData.amounts.Length > i)
            {
                newItem.count =
                    chestData.amounts[i];

                newItem.RefreshCount();
            }

            chestSlots[i].currentItem =
                newItem;
        }
    }
}
