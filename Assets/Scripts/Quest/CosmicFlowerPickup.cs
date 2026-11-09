using UnityEngine;
using UnityEngine.InputSystem;

public class CosmicFlowerPickup : MonoBehaviour
{
    public GameObject finalBridge;

    public GameObject bridgeBlocker;

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

            FlowerInventory.Instance.hasCosmicFlower = true;

            if (finalBridge != null)
            {
                finalBridge.SetActive(true);
            }

            if (bridgeBlocker != null)
            {
                bridgeBlocker.SetActive(false);
            }

            Destroy(gameObject);
        }
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
