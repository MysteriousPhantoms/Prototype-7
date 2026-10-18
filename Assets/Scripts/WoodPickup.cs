using UnityEngine;
using UnityEngine.InputSystem;

public class WoodPickup : MonoBehaviour
{
    private void Update()
    {
        GameObject player =
            GameObject.FindGameObjectWithTag("Player");

        if (player == null)
            return;

        float distance =
            Vector2.Distance(
                player.transform.position,
                transform.position);

        if (distance <= 1.5f)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                Debug.Log("Collected Wood");

                player.GetComponent<PlayerInventory>()
                    .AddWood(1);

                Destroy(gameObject);
            }
        }
    }
}
