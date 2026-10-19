using UnityEngine;
using UnityEngine.InputSystem;

public class BridgeBuilder : MonoBehaviour
{
    public GameObject bridgeToBuild;
    public GameObject bridgeBlocker;

    public int woodCost = 1;

    void Update()
    {
        if (!Keyboard.current.eKey.wasPressedThisFrame)
            return;

        GameObject player =
            GameObject.FindGameObjectWithTag("Player");

        PlayerInventory inventory =
            player.GetComponent<PlayerInventory>();

        float distance =
            Vector2.Distance(
                player.transform.position,
                transform.position);

        if (distance > 1.5f)
            return;

        if (inventory.wood < woodCost)
            return;

        inventory.wood -= woodCost;
        inventory.woodText.text = inventory.wood.ToString();

        bridgeToBuild.SetActive(true);

        if (bridgeBlocker != null)
        {
            bridgeBlocker.SetActive(false);
        }

        Destroy(gameObject);
    }
}
