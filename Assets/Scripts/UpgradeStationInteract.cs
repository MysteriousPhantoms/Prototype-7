using UnityEngine;
using UnityEngine.InputSystem;

public class UpgradeStationInteract : MonoBehaviour
{
    public GameObject upgradeUI;
    public GameObject inventoryUI;

    public Animator animator;

    private bool playerNearby;
    private bool opened;

    private void Update()
    {
        if (!playerNearby)
            return;

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            ToggleUpgradeStation();
        }
    }

    private void ToggleUpgradeStation()
    {
        opened = !opened;

        if (upgradeUI != null)
        {
            upgradeUI.SetActive(opened);
        }

        if (inventoryUI != null)
        {
            inventoryUI.SetActive(opened);
        }

        if (animator != null)
        {
            animator.SetBool("Open", opened);
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
        if (!other.CompareTag("Player"))
            return;

        playerNearby = false;
        opened = false;

        if (upgradeUI != null)
        {
            upgradeUI.SetActive(false);
        }

        if (inventoryUI != null)
        {
            inventoryUI.SetActive(false);
        }

        if (animator != null)
        {
            animator.SetBool("Open", false);
        }
    }
}
