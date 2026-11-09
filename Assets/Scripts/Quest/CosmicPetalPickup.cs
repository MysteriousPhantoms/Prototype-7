using UnityEngine;
using UnityEngine.InputSystem;

public class CosmicPetalPickup : MonoBehaviour
{
    private bool playerNearby;

    private bool collected;

    private void Update()
    {
        if (collected)
            return;

        if (!playerNearby)
            return;

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            collected = true;

            CosmicPetalManager.Instance
                .CollectPetal();

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(
        Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit2D(
        Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}
