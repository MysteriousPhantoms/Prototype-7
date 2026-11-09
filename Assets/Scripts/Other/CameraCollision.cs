using UnityEngine;

//This is a test script, so far so good.
public class CameraCollision : MonoBehaviour
{
    public Transform target;          // Player goes in here
    public float distance = 5f;       // set the distances here
    public float minDistance = 1f;
    public LayerMask collisionMask;

    void LateUpdate()
    {
        Vector3 dir = (transform.position - target.position).normalized;

        RaycastHit hit;

        if (Physics.Raycast(target.position, dir, out hit, distance, collisionMask))
        {
            transform.position = target.position + dir * Mathf.Max(minDistance, hit.distance - 0.2f);
        }
        else
        {
            transform.position = target.position + dir * distance;
        }
    }
}
