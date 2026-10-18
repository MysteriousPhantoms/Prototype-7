using UnityEngine;
using UnityEngine.InputSystem;

public class GridMovement : MonoBehaviour
{
    public float gridSize = 1f;

    void Update()
    {
        Vector2 direction = Vector2.zero;

        if (Keyboard.current.wKey.wasPressedThisFrame)
            direction = Vector2.up;

        else if (Keyboard.current.sKey.wasPressedThisFrame)
            direction = Vector2.down;

        else if (Keyboard.current.aKey.wasPressedThisFrame)
            direction = Vector2.left;

        else if (Keyboard.current.dKey.wasPressedThisFrame)
            direction = Vector2.right;

        if (direction != Vector2.zero)
        {
            TryMove(direction);
        }
    }

    void TryMove(Vector2 direction)
    {
        Vector2 targetPosition =
            (Vector2)transform.position +
            direction * gridSize;

        Collider2D hit =
            Physics2D.OverlapCircle(
                targetPosition,
                0.1f,
                LayerMask.GetMask("Wall")
            );

        if (hit == null)
        {
            transform.position = targetPosition;
        }
    }
}
