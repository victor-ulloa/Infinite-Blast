using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    [SerializeField] GameObject groundTile;
    [SerializeField] GameObject[] tilesPrefabs;
    Vector3 nextSpawnPoint;
    
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnTile();
        }
    }

    public void SpawnTile(bool shouldSpawnPickup = true, bool shouldSpawnObstacle = true)
    {
        GameObject obstacleToSpawn = tilesPrefabs[Random.Range(0, tilesPrefabs.Length)];
        GameObject tempTile = Instantiate(obstacleToSpawn, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = tempTile.transform.GetChild(1).transform.position;

    }
}
