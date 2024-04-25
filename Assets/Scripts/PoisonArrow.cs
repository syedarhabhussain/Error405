using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonArrow : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float speed;
    public float knockbackForce = 5f;
    GameObject player;
    Upgrades upg;
    int pierceCount;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180);

        player = GameObject.FindWithTag("Player");
        upg = player.GetComponent<Upgrades>();
        if (upg.pierceShot)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Damageable enemy = other.gameObject.GetComponent<Damageable>();
        if (enemy != null)
        {
            enemy.ChangeHealth(-1, "poison");
            enemy.setPoison();
        }
        Destroy(gameObject);
    }

    // For pierce upgrade
    void OnTriggerEnter2D(Collider2D other)
    {
        Damageable enemy = other.gameObject.GetComponent<Damageable>();
        if (enemy != null)
        {
            enemy.ChangeHealth(-1, "poison");
            enemy.setPoison();
            if (pierceCount < GameObject.FindWithTag("Player").GetComponent<Upgrades>().upgLevel)
                pierceCount++;
            else
                Destroy(gameObject);
        }
        else
            Destroy(gameObject);
    }
}
