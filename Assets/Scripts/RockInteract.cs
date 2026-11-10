using UnityEngine;
using UnityEngine.InputSystem;

public class RockInteract : MonoBehaviour
{
    public Animator animator;
    public GameObject stonePrefab;

    public float breakTime = 2f;

    public float animationInterval = 0.4f;

    private float currentBreakTime;
    private float animationTimer;

    private bool destroyed;

    private void Update()
    {
        if (destroyed)
            return;

        if (ToolManager.Instance.selectedTool != ToolType.Pickaxe)
        {
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
