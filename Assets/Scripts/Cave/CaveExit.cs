using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CaveExit : MonoBehaviour
{
    public string exitSceneName;

    public string spawnPointID = "CaveExit";

    private bool playerNearby;

    private void Update()
    {
        if (!playerNearby)
            return;

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (SceneTransitionManager.Instance != null)
            {
                SceneTransitionManager.Instance.spawnPointID =
                    spawnPointID;
            }

            SceneManager.LoadScene(exitSceneName);
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
