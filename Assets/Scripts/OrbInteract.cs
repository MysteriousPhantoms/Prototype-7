using UnityEngine;
using UnityEngine.InputSystem;

public class OrbInteract : MonoBehaviour
{
    public GameObject finalBridge;

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

        finalBridge.SetActive(true);

        Destroy(gameObject);
    }
}
