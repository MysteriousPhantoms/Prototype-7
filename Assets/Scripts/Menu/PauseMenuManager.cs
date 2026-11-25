using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenu;

    private bool paused;

    private void Start()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        paused = !paused;

        if (pauseMenu != null)
        {
            pauseMenu.SetActive(paused);
        }

        if (paused)
        {
            InventoryUIManager inventory =
                FindObjectOfType<InventoryUIManager>();

            if (inventory != null &&
                inventory.inventoryUI != null)
            {
                inventory.inventoryUI.SetActive(false);
            }
        }

        Time.timeScale =
            paused ? 0f : 1f;
    }

    public void ResumeGame()
    {
        paused = false;

        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }

        Time.timeScale = 1f;
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            "MainMenu");
    }

    public bool IsPaused()
    {
        return paused;
    }
}
