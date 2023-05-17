using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject Player;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Player) { return; }
        Vector3 currentPosition = gameObject.transform.position;
        currentPosition.x = Player.transform.position.x;
        gameObject.transform.position = currentPosition;
    }
}
