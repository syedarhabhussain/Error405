using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixieEnemy : MonoBehaviour
{
    Transform playerT;
    public Transform shotPoint;
    public Transform gun;
    public GameObject bullet;
    private SpriteRenderer sprite;
    private Animator anim;
    private Pathfinding.AIBase aipath;
    Vector3 direction;

    public bool canFire;
    public bool animFire;
    private float timer;
    public float timeBetweenFiring = 5f;
    public float atkRange;
    public int detectRange;
    Damageable dmg;

    void Start()
    {
        playerT = GameObject.FindWithTag("Player").transform;
        dmg = GetComponent<Damageable>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        aipath = GetComponent<Pathfinding.AIBase>();
    }

    void Update()
    {
        Vector3 difference = playerT.position - gun.transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        direction = playerT.position - transform.position;
        direction.Normalize();
        UpdateAnimation();

        //If enemy is ready to fire and player is in range
        if (canFire && Vector2.Distance(transform.position, playerT.position) <= atkRange)
        {
            timer = 0;
            canFire = false;
            animFire = true;
            Fire();
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
            }
        }

        if (Vector2.Distance(transform.position, playerT.position) <= detectRange)
        {
            aipath.canMove = true;
        }

        if (dmg.currentHealth <= 0)
        {
            Destroy(gameObject);
            GetComponent<LootBag>().InstantiateLoot(transform.position);
        }
    }

    void Fire()
    {
        Instantiate(bullet, playerT.position, shotPoint.transform.rotation);
    }

    //Draws a circle to help see what his range is
    /*
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, atkRange);
    }
    */
    void UpdateAnimation()
    {
        if (Mathf.Abs(direction.x) > 0f)
        {
            if (aipath.velocity != Vector3.zero)
            {
                anim.SetBool("Sprinting", true);
            }
            else
            {
                anim.SetBool("Sprinting", false);
            }

            if (direction.x > 0f)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
        }

        if (animFire)
        {
            anim.SetTrigger("Attack");
            animFire = false;
        }
    }
}
