using UnityEngine;
using UnityEngine.InputSystem;

public class BridgeBuilder : MonoBehaviour
{
    public GameObject bridgeToBuild;
    public GameObject bridgeBlocker;

    public ItemData woodItem;

    public int woodCost = 1;

    private void Update()
    {
        if (!Keyboard.current.eKey.wasPressedThisFrame)
            return;

        GameObject player =
            GameObject.FindGameObjectWithTag("Player");

        if (player == null)
            return;

        float distance =
            Vector2.Distance(
                player.transform.position,
                transform.position);

        if (distance > 1.5f)
            return;

        InventoryManager inventory =
            InventoryManager.Instance;

        if (inventory == null)
            return;

        InventoryItem woodStack = null;

        foreach (InventorySlot slot in inventory.inventorySlots)
        {
            if (slot.currentItem != null &&
                slot.currentItem.item == woodItem)
            {
                woodStack = slot.currentItem;
                break;
            }
        }

        if (woodStack == null)
        {
            Debug.Log("No Wood Found");
            return;
        }

        if (woodStack.count < woodCost)
        {
            Debug.Log("Not Enough Wood");
            return;
        }

        woodStack.count -= woodCost;
        woodStack.RefreshCount();

        if (woodStack.count <= 0)
        {
            InventorySlot slot =
                woodStack.GetComponentInParent<InventorySlot>();

            if (slot != null)
            {
                slot.currentItem = null;
            }

            Destroy(woodStack.gameObject);
        }

        bridgeToBuild.SetActive(true);

        if (bridgeBlocker != null)
        {
            bridgeBlocker.SetActive(false);
        }

        Destroy(gameObject);
    }
}
