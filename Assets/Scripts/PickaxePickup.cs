using UnityEngine;
using UnityEngine.InputSystem;

public class PickaxePickup : MonoBehaviour
{
    private bool playerNearby;

    private void Update()
    {
        if (playerNearby &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            GameObject player =
                GameObject.FindGameObjectWithTag("Player");

            player.GetComponent<PlayerInventory>().hasPickaxe = true;

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
