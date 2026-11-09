using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CaveEntrance : MonoBehaviour
{
    public string caveSceneName = "Cave";

    private bool playerNearby;

    private void Update()
    {
        if (!playerNearby)
            return;

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(caveSceneName);
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
