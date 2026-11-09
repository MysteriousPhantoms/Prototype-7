using UnityEngine;
using UnityEngine.InputSystem;

public class TreeInteract : MonoBehaviour
{
    public Animator animator;
    public GameObject woodPrefab;

    public int hitsRequired = 3;

    private int hits = 0;

    private bool destroyed;

    private void Update()
    {
        if (destroyed)
            return;

        if (!Keyboard.current.eKey.wasPressedThisFrame)
            return;

        if (ToolManager.Instance.selectedTool != ToolType.Axe)
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

        hits++;

        animator.SetTrigger("Break");

        if (hits >= hitsRequired)
        {
            destroyed = true;

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
