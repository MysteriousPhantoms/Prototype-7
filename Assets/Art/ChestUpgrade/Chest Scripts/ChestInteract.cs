using UnityEngine;
using UnityEngine.InputSystem;

public class ChestInteract : MonoBehaviour
{
    public ChestData chestData;

    public GameObject chestUI;

    public Animator animator;

    private bool playerNearby;

    private bool opened;

    private void Update()
    {
        if (!playerNearby)
            return;

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            ToggleChest();
        }
    }

    private void ToggleChest()
    {
        opened = !opened;

        chestUI.SetActive(opened);

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

        if (chestUI != null)
        {
            chestUI.SetActive(false);
        }

        if (animator != null)
        {
            animator.SetBool("Open", false);
        }
    }
}
