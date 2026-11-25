using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject inventoryUI;

    public PauseMenuManager pauseMenuManager;

    private void Start()
    {
        if (inventoryUI != null)
        {
            inventoryUI.SetActive(false);
        }
    }

    private void Update()
    {
        if (pauseMenuManager != null &&
            pauseMenuManager.IsPaused())
        {
            return;
        }

        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            inventoryUI.SetActive(
                !inventoryUI.activeSelf);
        }
    }
}
