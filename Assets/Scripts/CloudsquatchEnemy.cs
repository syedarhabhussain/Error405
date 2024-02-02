using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.Rendering.Universal;

public class CloudsquatchEnemy : MonoBehaviour
{
    Transform playerT;
    private Animator anim;
    private SpriteRenderer sprite;
    public ParticleSystem dust;
    [SerializeField] GameObject minisquatch;

    private Rigidbody2D rb;
    Vector3 direction;
    bool attack;
    Damageable dmg;
    private Pathfinding.AIBase aipath;
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
            GetComponent<LootBag>().InstantiateLoot(transform.position);
            Spawn();
        }
        if (Vector2.Distance(transform.position, playerT.position) <= detectRange)
        {
            aipath.canMove = true;
        }
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
            attack = true;
        }
    }

    void Spawn()
    {
        Instantiate(minisquatch, transform.position, Quaternion.identity);
        Instantiate(minisquatch, transform.position, Quaternion.identity);
    }

    void UpdateAnimation()
    {
        if (Mathf.Abs(direction.x) > 0f)
        {
            if (aipath.velocity != Vector3.zero)
            {
                anim.SetBool("Sprinting", true);
                createDust();
            }
            else
            {
                anim.SetBool("Sprinting", false);
            }
            //anim.SetFloat("Speed", Mathf.Abs(aipath.velocity));
            if (direction.x < 0f && aipath.velocity == Vector3.zero)
            {
                sprite.flipX = true;
            }
            else if (direction.x >= 0f && aipath.velocity == Vector3.zero)
            {
                sprite.flipX = false;
            }
        }

        if (attack)
        {
            anim.SetTrigger("Attack");
            attack = false;
        }
    }

    void createDust()
    {
        dust.Play();
    }
}
