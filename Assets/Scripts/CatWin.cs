using UnityEngine;
using UnityEngine.InputSystem;

public class CatWin : MonoBehaviour
{
    public GameObject winScreen;

    void Update()
    {
        if (!Keyboard.current.eKey.wasPressedThisFrame)
            return;

        GameObject player =
            GameObject.FindGameObjectWithTag("Player");

        if (player == null)
            return;

        float distance =
            Vector2.Distance(
                player.transform.position,
                transform.position);

        if (distance > 1.5f)
            return;

        winScreen.SetActive(true);
    }
}
