using UnityEngine;
using UnityEngine.InputSystem;

public class CatWin : MonoBehaviour
{
    public GameObject winScreen;

    private void Update()
    {
        if (!Keyboard.current.eKey.wasPressedThisFrame)
            return;

        if (!FlowerInventory.Instance.hasCosmicFlower)
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

        FlowerInventory.Instance.hasCosmicFlower = false;
    }
}
