using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    [Header("Basic Info")]
    public string itemName;

    public Sprite icon;

    [Header("Inventory")]
    public bool stackable = true;

    public int maxStack = 99;

    [Header("Type")]
    public ItemType itemType;

    [Header("Tool")]
    public ToolType toolType;

    [Header("Tool Tier")]
    public ToolTier toolTier;
}

public enum ItemType
{
    Resource,
    Tool,
    Quest
}

public enum ToolType
{
    None,
    Axe,
    Pickaxe
}

public enum ToolTier
{
    None,
    Wood,
    Stone,
    Iron,
    Gold,
    Diamond
}
