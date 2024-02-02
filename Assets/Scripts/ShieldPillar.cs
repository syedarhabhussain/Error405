using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPillar : MonoBehaviour
{
    [SerializeField] int maxHealth;
    private int currentHealth;
    [SerializeField] GameObject healthPot;
    Vector2 startingPos;
    EnemyHealthbar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        startingPos.x = transform.position.x;
        startingPos.y = transform.position.y;
        healthbar = GetComponentInChildren<EnemyHealthbar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Spawn();
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "PlayerProjectile")
        {
            currentHealth--;
            healthbar.UpdateHealthbar(currentHealth, maxHealth);
            StartCoroutine(Shake());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerProjectile")
        {
            currentHealth--;
            healthbar.UpdateHealthbar(currentHealth, maxHealth);
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
        Instantiate(healthPot, transform.position, Quaternion.identity);
    }
}
