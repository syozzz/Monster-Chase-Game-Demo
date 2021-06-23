using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constant.TAG_ENEMY_NAME) ||
            collision.CompareTag(Constant.TAG_PLAYER_NAME))
            Destroy(collision.gameObject);
    }
}
