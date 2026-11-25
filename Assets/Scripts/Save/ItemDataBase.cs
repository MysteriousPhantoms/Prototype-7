using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase Instance;

    public ItemData[] allItems;

    private void Awake()
    {
        Instance = this;
    }

    public ItemData GetItemByName(string itemName)
    {
        foreach (ItemData item in allItems)
        {
            if (item.itemName == itemName)
            {
                return item;
            }
        }

        return null;
    }
}
