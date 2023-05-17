using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;

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

}
