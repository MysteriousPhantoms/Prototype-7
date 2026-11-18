using UnityEngine;
using UnityEngine.InputSystem;

public class BridgeBuilder : MonoBehaviour
{
    public GameObject bridgeToBuild;
    public GameObject bridgeBlocker;

    [Header("Required Resource")]
    public ItemData requiredItem;

    public int requiredAmount = 1;

    private bool playerNearby;

    private void Update()
    {
        if (!playerNearby)
            return;

        if (!Keyboard.current.eKey.wasPressedThisFrame)
            return;

        InventoryManager inventory =
            InventoryManager.Instance;

        if (inventory == null)
            return;

        int totalResources = 0;

        foreach (InventorySlot slot in inventory.inventorySlots)
        {
            if (slot.currentItem != null &&
                slot.currentItem.item == requiredItem)
            {
                totalResources +=
                    slot.currentItem.count;
            }
        }

        if (totalResources < requiredAmount)
        {
            Debug.Log(
                "Need " +
                requiredAmount +
                " " +
                requiredItem.itemName);

            return;
        }

        int remainingCost =
            requiredAmount;

        foreach (InventorySlot slot in inventory.inventorySlots)
        {
            if (slot.currentItem == null)
                continue;

            if (slot.currentItem.item != requiredItem)
                continue;

            InventoryItem stack =
                slot.currentItem;

            int removeAmount =
                Mathf.Min(
                    stack.count,
                    remainingCost);

            stack.count -= removeAmount;

            stack.RefreshCount();

            remainingCost -= removeAmount;

            if (stack.count <= 0)
            {
                slot.currentItem = null;

                Destroy(stack.gameObject);
            }

            if (remainingCost <= 0)
                break;
        }

        if (bridgeToBuild != null)
        {
            bridgeToBuild.SetActive(true);
        }

        if (bridgeBlocker != null)
        {
            bridgeBlocker.SetActive(false);
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}
