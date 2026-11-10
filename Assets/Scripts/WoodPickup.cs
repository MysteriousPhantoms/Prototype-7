using UnityEngine;
using UnityEngine.InputSystem;

public class WoodPickup : MonoBehaviour
{
    public ItemData woodItem;

    private bool canCollect;

    private void Update()
    {
        if (!Keyboard.current.eKey.isPressed)
        {
            canCollect = true;
        }

        if (!canCollect)
            return;

        GameObject player =
            GameObject.FindGameObjectWithTag("Player");

        if (player == null)
            return;

        float distance =
            Vector2.Distance(
                transform.position,
                player.transform.position);

        if (distance <= 1.5f &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            InventoryManager inventory =
                FindObjectOfType<InventoryManager>();

            if (inventory == null)
            {
                Debug.LogError("No InventoryManager found!");
                return;
            }

            if (woodItem == null)
            {
                Debug.LogError("Wood Item not assigned!");
                return;
            }

            inventory.AddItem(woodItem);

            Destroy(gameObject);
        }
    }
}
