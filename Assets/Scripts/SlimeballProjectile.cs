using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeballProjectile : MonoBehaviour
{
    Transform playerT;
    Vector3 endPos;
    public float speed = 5;
    public GameObject puddle;
    public GameObject warning;
    GameObject warn;
    // Start is called before the first frame update
    void Start()
    {
        playerT = GameObject.FindWithTag("Player").transform;
        endPos = playerT.position;
        warn = Instantiate(warning, endPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
        if (transform.position == endPos)
        {
            SpawnPuddle(warn);
            Destroy(gameObject);
        }
    }

    void SpawnPuddle(GameObject warn)
    {
        Destroy(warn);
        Instantiate(puddle, endPos, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
        Destroy(gameObject);
        Destroy(warn);
    }
}
