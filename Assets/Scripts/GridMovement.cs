using UnityEngine;
using UnityEngine.InputSystem;

public class GridMovement : MonoBehaviour
{
    public float gridSize = 1f;

    public float moveSpeed = 5f;

    public LayerMask blockingLayers;

    public Vector2 gridOffset =
        new Vector2(-0.5f, 0.5f);

    private bool moving;

    private Vector3 targetPosition;

    private void Start()
    {
        SnapToGrid();

        targetPosition = transform.position;
    }

    private void Update()
    {
        if (moving)
        {
            transform.position =
                Vector3.MoveTowards(
                    transform.position,
                    targetPosition,
                    moveSpeed * Time.deltaTime);

            if (Vector3.Distance(
                transform.position,
                targetPosition) < 0.001f)
            {
                transform.position =
                    targetPosition;

                moving = false;
            }

            return;
        }

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

    private void TryMove(Vector2 direction)
    {
        Vector2 currentTile =
            new Vector2(
                Mathf.Round(
                    (transform.position.x -
                    gridOffset.x) / gridSize)
                    * gridSize +
                    gridOffset.x,

                Mathf.Round(
                    (transform.position.y -
                    gridOffset.y) / gridSize)
                    * gridSize +
                    gridOffset.y
            );

        Vector2 targetTile =
            currentTile +
            direction * gridSize;

        Collider2D hit =
            Physics2D.OverlapBox(
                targetTile,
                new Vector2(0.8f, 0.8f),
                0f,
                blockingLayers);

        if (hit != null)
            return;

        targetPosition =
            new Vector3(
                targetTile.x,
                targetTile.y,
                transform.position.z);

        moving = true;
    }

    private void SnapToGrid()
    {
        transform.position =
            new Vector3(
                Mathf.Round(
                    (transform.position.x -
                    gridOffset.x) / gridSize)
                    * gridSize +
                    gridOffset.x,

                Mathf.Round(
                    (transform.position.y -
                    gridOffset.y) / gridSize)
                    * gridSize +
                    gridOffset.y,

                transform.position.z);
    }
}
