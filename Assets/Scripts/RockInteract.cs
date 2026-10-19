using UnityEngine;
using UnityEngine.InputSystem;

public class RockInteract : MonoBehaviour
{
    public Animator animator;
    public GameObject stonePrefab;

    public int hitsRequired = 2;

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

        if (!inventory.hasPickaxe)
            return;

        float distance =
            Vector2.Distance(
                player.transform.position,
                transform.position);

        if (distance > 1.5f)
            return;

        hits++;

        animator.SetTrigger("Break");

        if (hits >= hitsRequired)
        {
            if (stonePrefab != null)
            {
                Instantiate(
                    stonePrefab,
                    transform.position,
                    Quaternion.identity);
            }

            GetComponent<BoxCollider2D>().enabled = false;

            Destroy(gameObject, 0.2f);
        }
    }
}
