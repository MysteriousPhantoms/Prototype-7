using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [Header("Basic Info")]
    public string itemName;
    public Sprite icon;

    [Header("Inventory")]
    public bool stackable = true;
    public int maxStack = 99;

    [Header("Item Type")]
    public ItemType itemType;

    [Header("Tool Settings")]
    public ToolType toolType;

    [Header("Building")]
    public int buildCost;
}

public enum ItemType
{
    Resource,
    Tool,
    QuestItem,
    Consumable,
    Building
}

public enum ToolType
{
    None,
    Axe,
    Pickaxe
}
