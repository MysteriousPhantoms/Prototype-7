using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class ItemData : MonoBehaviour
{
    public string itemName;

    public Sprite icon;

    public bool stackable = true;

    public int maxStack = 99;

    public ItemType itemType;
}

public enum ItemType
{
    Resource,
    Tool,
    Quest
}
