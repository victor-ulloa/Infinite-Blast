using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;
    
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnTile(false, i>3);
        }
    }

    public void SpawnTile(bool shouldSpawnPickup = true, bool shouldSpawnObstacle = true)
    {
        GameObject tempTile = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = tempTile.transform.GetChild(1).transform.position;
        GroundTile tempGroundTile = tempTile.GetComponent<GroundTile>();

        if (shouldSpawnPickup) {
            tempGroundTile.SpawnPickup();
        }
        if (shouldSpawnObstacle) {
            tempGroundTile.SpawnObstacle();
        }
        
    }
}
