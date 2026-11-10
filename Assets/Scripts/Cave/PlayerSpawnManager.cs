using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    private void Start()
    {
        if (SceneTransitionManager.Instance == null)
            return;

        if (string.IsNullOrEmpty(
            SceneTransitionManager.Instance.spawnPointID))
            return;

        GameObject player =
            GameObject.FindGameObjectWithTag("Player");

        if (player == null)
            return;

        SpawnPoint[] points =
            FindObjectsOfType<SpawnPoint>();

        foreach (SpawnPoint point in points)
        {
            if (point.spawnPointID ==
                SceneTransitionManager.Instance.spawnPointID)
            {
                player.transform.position =
                    point.transform.position;

                break;
            }
        }
    }
}
