using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Chest Data")]
public class ChestData : ScriptableObject
{
    public ItemData[] items;

    public int[] amounts;
}
