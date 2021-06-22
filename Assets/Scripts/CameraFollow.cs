using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform player;

    private Vector3 tempPos;

    [SerializeField]
    private float minX = -60f;

    [SerializeField]
    private float maxX = 60f;

    private const string TAG_PLAYER_NAME = "Player";

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(TAG_PLAYER_NAME).transform;
    }


    private void LateUpdate()
    {
        tempPos = transform.position;
        tempPos.x = player.position.x;

        if (tempPos.x < minX)
        {
            tempPos.x = minX;
        }
        else if (tempPos.x > maxX )
        {
            tempPos.x = maxX;
        }

        transform.position = tempPos;
    }
}
