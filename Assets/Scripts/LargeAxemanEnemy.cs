using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.Rendering.Universal;

public class LargeAxemanEnemy : MonoBehaviour
{
    Transform playerT;
    private Animator anim;
    private SpriteRenderer sprite;
    public GameObject healthPot;

    private Rigidbody2D rb;
    Vector3 direction;
    bool attack;
    Damageable dmg;
    private Pathfinding.AIBase aipath;
    [SerializeField] int attackRange;
    [SerializeField] int detectRange;


    // Start is called before the first frame update

    void Start()
    {
        playerT = GameObject.FindWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        dmg = GetComponent<Damageable>();
        aipath = GetComponent<Pathfinding.AIBase>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = playerT.position - transform.position;
        direction.Normalize();

        if (dmg.currentHealth <= 0)
        {
            Destroy(gameObject);
            //GetComponent<LootBag>().InstantiateLoot(transform.position);
            Instantiate(healthPot, transform.position, Quaternion.identity);
            Instantiate(healthPot, transform.position, Quaternion.identity);

        }

        if (Vector2.Distance(transform.position, playerT.position) <= detectRange)
        {
            aipath.canMove = true;
        }

        if (Vector2.Distance(transform.position, playerT.position) <= attackRange)
        {
            aipath.maxSpeed = 4;
            attack = true;
        }
        else
        { 
            aipath.maxSpeed = 1;
            attack = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void FixedUpdate()
    {
        UpdateAnimation();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
           // attack = true;
        }
    }

    void UpdateAnimation()
    {
        if (Mathf.Abs(direction.x) > 0f)
        {
            if (aipath.velocity != Vector3.zero)
            {
               // anim.SetBool("Sprinting", true);
            }
            else
            {
            //    anim.SetBool("Sprinting", false);
            }
            //anim.SetFloat("Speed", Mathf.Abs(aipath.velocity));
            if (direction.x < 0f)
            {
                sprite.flipX = false;
            }
            else if (direction.x >= 0f)
            {
                sprite.flipX = true;
            }
        }

        anim.SetBool("Attack", attack);
 
    }
}
