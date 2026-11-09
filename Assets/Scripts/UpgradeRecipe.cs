using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Upgrade Recipe")]
public class UpgradeRecipe : ScriptableObject
{
    public ItemData toolInput;

    public ItemData resourceInput;

    public int resourceCost;

    public ItemData resultItem;
}
