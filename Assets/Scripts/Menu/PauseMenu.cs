using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private bool paused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        paused = !paused;

        pauseMenuUI.SetActive(paused);

        Time.timeScale =
            paused ? 0f : 1f;
    }

    public void ResumeGame()
    {
        paused = false;

        pauseMenuUI.SetActive(false);

        Time.timeScale = 1f;
    }
}
