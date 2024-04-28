using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandCompleted : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;

    void OnCollisionEnter2D(Collision2D other)
    {
        player = other.gameObject;
        if (player != null)
        {
            Destroy(enemy);
        }

    }
}
