using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

    [SerializeField] Transform[] obstacleSpawnPoints;
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] Transform[] pickupSpawnPoints;
    [SerializeField] GameObject[] pickupPrefabs;

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            groundSpawner.SpawnTile();
            Destroy(gameObject, 2);
        }
    }

    public void SpawnObstacle()
    {
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        Transform spawnPoint = obstacleSpawnPoints[Random.Range(0, obstacleSpawnPoints.Length)];
        Instantiate(obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnPickup()
    {
        GameObject pickupToSpawn = pickupPrefabs[Random.Range(0, pickupPrefabs.Length)];
        Transform spawnPoint = pickupSpawnPoints[Random.Range(0, obstacleSpawnPoints.Length)];
        Instantiate(pickupToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }
}
