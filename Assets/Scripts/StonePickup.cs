using UnityEngine;
using UnityEngine.InputSystem;

public class StonePickup : MonoBehaviour
{
    public ItemData stoneItem;

    private void Update()
    {
        GameObject player =
            GameObject.FindGameObjectWithTag("Player");

        if (player == null)
            return;

        float distance = Vector2.Distance(
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

            if (stoneItem == null)
            {
                Debug.LogError("Stone Item not assigned!");
                return;
            }

            inventory.AddItem(stoneItem);

            Destroy(gameObject);
        }
    }
}
