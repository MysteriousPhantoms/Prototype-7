using UnityEngine;
using UnityEngine.InputSystem;

public class AxePickup : MonoBehaviour
{
    private bool playerNearby;

    private void Update()
    {
        if (playerNearby &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            GameObject player =
                GameObject.FindGameObjectWithTag("Player");

            player.GetComponent<PlayerInventory>().hasAxe = true;

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
