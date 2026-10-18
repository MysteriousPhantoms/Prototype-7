using UnityEngine;
using UnityEngine.InputSystem;

public class TreeInteract : MonoBehaviour
{
    public Animator animator;
    public GameObject woodPrefab;

    public int hitsRequired = 3;

    private int hits = 0;

    void Update()
    {
        if (!Keyboard.current.eKey.wasPressedThisFrame)
            return;

        GameObject player =
            GameObject.FindGameObjectWithTag("Player");

        if (player == null)
            return;

        PlayerInventory inventory =
            player.GetComponent<PlayerInventory>();

        if (!inventory.hasAxe)
            return;

        float distance =
            Vector2.Distance(
                player.transform.position,
                transform.position);

        if (distance > 1.25f)
            return;

        hits++;

        animator.SetTrigger("Break");

        if (hits >= hitsRequired)
        {
            if (woodPrefab != null)
            {
                Instantiate(
                    woodPrefab,
                    transform.position,
                    Quaternion.identity);
            }

            GetComponent<BoxCollider2D>().enabled = false;

            Destroy(gameObject, 0.2f);
        }
    }
}
