using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public InventoryItem currentItem;

    public bool IsEmpty()
    {
        return currentItem == null;
    }
}
