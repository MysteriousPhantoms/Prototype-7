using UnityEngine;
using UnityEngine.InputSystem;

public class HarvestInteract : MonoBehaviour
{
    public Animator animator;

    public GameObject dropPrefab;

    public ToolType requiredTool;

    public ToolTier requiredTier;

    public float breakTime = 2f;

    public float animationInterval = 0.4f;

    private float currentBreakTime;
    private float animationTimer;

    private bool destroyed;

    private void Update()
    {
        if (destroyed)
            return;

        if (ToolManager.Instance == null)
            return;

        if (ToolManager.Instance.selectedTool != requiredTool)
        {
            currentBreakTime = 0f;
            animationTimer = 0f;
            return;
        }

        if (ToolManager.Instance.selectedToolTier <
            requiredTier)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                UpgradeRequiredUI.Instance
                    .ShowMessage(
                        requiredTier +
                        " Tool Required!");
            }

            currentBreakTime = 0f;
            animationTimer = 0f;
            return;
        }

        GameObject player =
            GameObject.FindGameObjectWithTag("Player");

        if (player == null)
            return;

        float distance =
            Vector2.Distance(
                player.transform.position,
                transform.position);

        if (distance > 1.5f)
        {
            currentBreakTime = 0f;
            animationTimer = 0f;
            return;
        }

        if (!Keyboard.current.eKey.isPressed)
        {
            currentBreakTime = 0f;
            animationTimer = 0f;
            return;
        }

        currentBreakTime += Time.deltaTime;
        animationTimer += Time.deltaTime;

        if (animationTimer >= animationInterval)
        {
            animationTimer = 0f;

            if (animator != null)
            {
                animator.SetTrigger("Break");
            }
        }

        if (currentBreakTime >= breakTime)
        {
            destroyed = true;

            if (dropPrefab != null)
            {
                Instantiate(
                    dropPrefab,
                    transform.position,
                    Quaternion.identity);
            }

            Collider2D col =
                GetComponent<Collider2D>();

            if (col != null)
            {
                col.enabled = false;
            }

            Destroy(gameObject, 0.2f);
        }
    }
}
