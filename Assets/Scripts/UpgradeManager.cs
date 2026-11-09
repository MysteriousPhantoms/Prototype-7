using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    [Header("Slots")]
    public InventorySlot toolSlot;
    public InventorySlot resourceSlot;

    [Header("Preview")]
    public Image resultImage;
    public TextMeshProUGUI costText;

    [Header("Recipes")]
    public UpgradeRecipe[] recipes;

    private UpgradeRecipe currentRecipe;

    private void Update()
    {
        UpdatePreview();
    }

    private void UpdatePreview()
    {
        currentRecipe = null;

        if (resultImage != null)
        {
            resultImage.enabled = false;
        }

        if (costText != null)
        {
            costText.text = "";
        }

        if (toolSlot.currentItem == null)
            return;

        foreach (UpgradeRecipe recipe in recipes)
        {
            if (toolSlot.currentItem.item != recipe.toolInput)
                continue;

            // Show result preview
            if (resultImage != null)
            {
                resultImage.sprite = recipe.resultItem.icon;
                resultImage.enabled = true;
            }

            // Dynamic upgrade info
            if (costText != null)
            {
                costText.text =
                    recipe.toolInput.itemName +
                    " → " +
                    recipe.resultItem.itemName +
                    "\nCost: " +
                    recipe.resourceCost +
                    " " +
                    recipe.resourceInput.itemName;
            }

            // Resource checks
            if (resourceSlot.currentItem == null)
                return;

            if (resourceSlot.currentItem.item != recipe.resourceInput)
                return;

            if (resourceSlot.currentItem.count < recipe.resourceCost)
                return;

            currentRecipe = recipe;

            return;
        }
    }

    public void Upgrade()
    {
        if (currentRecipe == null)
            return;

        InventoryItem tool =
            toolSlot.currentItem;

        InventoryItem resource =
            resourceSlot.currentItem;

        // Remove tool
        toolSlot.currentItem = null;
        Destroy(tool.gameObject);

        // Remove resource cost
        resource.count -= currentRecipe.resourceCost;
        resource.RefreshCount();

        if (resource.count <= 0)
        {
            resourceSlot.currentItem = null;
            Destroy(resource.gameObject);
        }

        // Add upgraded tool to toolbar
        InventoryManager.Instance.AddItem(
            currentRecipe.resultItem
        );

        // Clear preview
        if (resultImage != null)
        {
            resultImage.enabled = false;
        }

        if (costText != null)
        {
            costText.text = "";
        }

        currentRecipe = null;
    }
}
