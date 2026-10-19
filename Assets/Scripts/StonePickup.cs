using UnityEngine;
using UnityEngine.InputSystem;

public class StonePickup : MonoBehaviour
{
    void Update()
    {
        GameObject player =
            GameObject.FindGameObjectWithTag("Player");

        if (player == null)
            return;

        float distance =
            Vector2.Distance(
                transform.position,
                player.transform.position);

        if (distance <= 1.5f &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            player.GetComponent<PlayerInventory>()
                .AddStone(1);

            Destroy(gameObject);
        }
    }
}
