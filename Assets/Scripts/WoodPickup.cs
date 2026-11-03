using UnityEngine;
using UnityEngine.InputSystem;

public class WoodPickup : MonoBehaviour
{
    public ItemData woodItem;

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

            inventory.AddItem(woodItem);

            Destroy(gameObject);
        }
    }
}
