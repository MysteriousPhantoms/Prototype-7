using UnityEngine;
using UnityEngine.InputSystem;

public class PickaxePickup : MonoBehaviour
{
    public ItemData pickaxeItem;

    private bool playerNearby;

    private void Update()
    {
        if (playerNearby &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            InventoryManager inventory =
                FindObjectOfType<InventoryManager>();

            inventory.AddItem(pickaxeItem);

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNearby = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNearby = false;
    }
}
