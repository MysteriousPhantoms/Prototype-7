using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public static ToolManager Instance;

    public ToolType selectedTool = ToolType.None;

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

    public void SelectTool(ItemData item)
    {
        if (item == null)
            return;

        if (item.itemType == ItemType.Tool)
        {
            selectedTool = item.toolType;

            Debug.Log("Selected Tool: " + selectedTool);
        }
    }
}
