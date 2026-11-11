using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public static ToolManager Instance;

    public ToolType selectedTool = ToolType.None;

    public ToolTier selectedToolTier = ToolTier.None;

    private InventorySlot currentSelectedSlot;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SelectTool(ItemData item, InventorySlot slot)
    {
        if (item == null)
            return;

        if (item.itemType != ItemType.Tool)
            return;

        // Clicking same tool again unequips
        if (currentSelectedSlot == slot)
        {
            currentSelectedSlot.Deselect();

            currentSelectedSlot = null;

            selectedTool = ToolType.None;
            selectedToolTier = ToolTier.None;

            Debug.Log("Tool Unequipped");

            return;
        }

        if (currentSelectedSlot != null)
        {
            currentSelectedSlot.Deselect();
        }

        currentSelectedSlot = slot;

        currentSelectedSlot.Select();

        selectedTool = item.toolType;
        selectedToolTier = item.toolTier;

        Debug.Log(
            "Selected Tool: " +
            selectedTool +
            " | Tier: " +
            selectedToolTier);
    }

    public void UnequipTool()
    {
        if (currentSelectedSlot != null)
        {
            currentSelectedSlot.Deselect();

            currentSelectedSlot = null;
        }

        selectedTool = ToolType.None;
        selectedToolTier = ToolTier.None;

        Debug.Log("Tool Unequipped");
    }
}
