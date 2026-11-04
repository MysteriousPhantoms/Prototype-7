using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public static ToolManager Instance;

    public ToolType selectedTool = ToolType.None;

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

        if (currentSelectedSlot != null)
        {
            currentSelectedSlot.Deselect();
        }

        currentSelectedSlot = slot;

        currentSelectedSlot.Select();

        selectedTool = item.toolType;

        Debug.Log("Selected Tool: " + selectedTool);
    }
}
