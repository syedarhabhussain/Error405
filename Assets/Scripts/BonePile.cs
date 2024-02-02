using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonePile : MonoBehaviour
{
    [SerializeField] int maxHealth;
    private int currentHealth;
    [SerializeField] GameObject enemies;
    [SerializeField] GameObject skeleton;
    [SerializeField] GameObject healthPot;
    [SerializeField] GameObject multiShot;
    [SerializeField] int detectRange;
    Transform playerT;
    Vector2 startingPos;
    // Start is called before the first frame update
    void Start()
    {
        playerT = GameObject.FindWithTag("Player").transform;
        currentHealth = maxHealth;
        startingPos.x = transform.position.x;
        startingPos.y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Spawn();
            Destroy(gameObject);
        }

        if (Vector2.Distance(transform.position, playerT.position) <= detectRange)
        {
            Spawn();
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "PlayerProjectile")
        {
            currentHealth--;
            StartCoroutine(Shake());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerProjectile")
        {
            currentHealth--;
            StartCoroutine(Shake());
        }
    }

        IEnumerator Shake()
    {
        float currTime = 0f;
        while (currTime < .1)
        { 
            transform.position = new Vector2(startingPos.x + Mathf.Sin(Time.time * 50f) * .05f, startingPos.y);
            yield return null;
            currTime += Time.deltaTime;
        }
    }

    void Spawn()
    {
        int num = Random.Range(1, 101);
        //95% chance for skeleton to spawn
        if (num <= 95)
            Instantiate(skeleton, transform.position, Quaternion.identity, enemies.transform);
        else
        {
            //5% chance for health potion
            Instantiate(healthPot, transform.position, Quaternion.identity);
        }
    }
}
