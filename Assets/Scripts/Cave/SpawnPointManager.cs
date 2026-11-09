using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    private void Start()
    {
        SpawnPoint[] points =
            FindObjectsOfType<SpawnPoint>();

        foreach (SpawnPoint point in points)
        {
            if (point.spawnPointID ==
                SceneTransitionManager.Instance.spawnPointID)
            {
                GameObject player =
                    GameObject.FindGameObjectWithTag("Player");

                player.transform.position =
                    point.transform.position;

                break;
            }
        }
    }
}
