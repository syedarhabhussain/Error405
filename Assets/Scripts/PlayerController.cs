using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    public AudioSource audioSource;

    public int maxHealth = 6;
    public int health { get { return currentHealth; } }
    public int currentHealth;
    public Vector3 savedCheckpoint;
    int savedHealth;
    bool isInvincible;
    bool isSprinting;
    float invincibleTimer;
    public float hurtDelay = 1.0f;

    public float moveSpeed;
    private Vector2 moveDirection;
    float moveX;
    float moveY;
    public float walkSpeed = 4f;
    public float runSpeed = 6f;
    float stamina = 100f;
    float maxStamina = 100f;
    public bool rolling;
    public bool invRolling;
    public bool slowed;

    public GameOverScreen gameOver;

    public GameObject bow;

    public ParticleSystem dust;

    public Slider staminaBar;

    private CameraController camController;
    private changeLight lightScript;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        //audioSource.clip = audioClip;
        //currentHealth = maxHealth;
        camController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        lightScript = GameObject.FindGameObjectWithTag("light").GetComponent<changeLight>();
        moveSpeed = walkSpeed;
        savedHealth = PlayerPrefs.GetInt("Health", 6);
        currentHealth = savedHealth;


        if(PlayerPrefs.GetInt("bossCheck") == 1)
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("bossX"), PlayerPrefs.GetFloat("bossY"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

        if (currentHealth <= 0)
        {
            gameOver.Setup();
        }

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        UpdateAnimation();

    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        
        if (Input.GetKeyDown(KeyCode.Space) && (Mathf.Abs(moveX) > 0f || Mathf.Abs(moveY) > 0f) && stamina >= 25)
        {
            rolling = true;
            invRolling = true;
            Physics2D.IgnoreLayerCollision(6,8,true);
            Physics2D.IgnoreLayerCollision(6,13,true);
            stamina -= 25f;
        }

        if (Input.GetKey(KeyCode.LeftShift) && (Mathf.Abs(moveX) > 0f || Mathf.Abs(moveY) > 0f))
        {
            if (stamina > 0)
            {
                stamina -= 20f * Time.deltaTime;
                createDust();
                if (moveSpeed != runSpeed)
                {
                    moveSpeed = runSpeed;
                    if (slowed)
                        moveSpeed /= 2;
                    isSprinting = true;
                }
            }
            else
            {
                moveSpeed = walkSpeed;
                if(slowed)
                    moveSpeed /= 2;
                isSprinting = false;
            }
        }
        else
        {
            isSprinting = false;

            if (stamina <= maxStamina)
            {
                stamina += 10f * Time.deltaTime;
                if (moveSpeed != walkSpeed)
                {
                    moveSpeed = walkSpeed;
                    if(slowed)
                        moveSpeed /= 2;
                }
            }
        }
        staminaBar.value = stamina;

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        if (invRolling)
        {
            createDust();
            rb.AddForce(moveDirection * 25f, ForceMode2D.Force);
        }
        else if (!anim.GetBool("Falling"))
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

            bool isMoving = Mathf.Abs(moveDirection.x) > 0f || Mathf.Abs(moveDirection.y) > 0f;

            /*if (isMoving)
            {
                createDust();
            }*/
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void UpdateAnimation()
    {

        if (bow.transform.position.x < transform.position.x)
        {
            sprite.flipX = true;
            
        }
        else
        {
            sprite.flipX = false;
        }


        if (Mathf.Abs(moveX) > 0f)
        {
            anim.SetFloat("Speed", Mathf.Abs(moveX));

            if (isSprinting)
            {
                anim.SetBool("Sprinting", true);
            }
            else
            {
                anim.SetBool("Sprinting", false);
            }
        }
        else if (Mathf.Abs(moveY) > 0f)
        {
            anim.SetFloat("Speed", Mathf.Abs(moveY));

            if (isSprinting)
            {
                anim.SetBool("Sprinting", true);
            }
            else
            {
                anim.SetBool("Sprinting", false);
            }
        }
        else
        {
            anim.SetFloat("Speed", 0f);
        }

        if (rolling)
        {
            anim.SetTrigger("Roll");
            rolling = false;
            bow.SetActive(false);
            StartCoroutine(setRoll());
        }
    }

    IEnumerator setRoll()
    {
        yield return new WaitForSeconds(0.3f);
        invRolling = false;
        bow.SetActive(true);
        Physics2D.IgnoreLayerCollision(6, 8, false);
        Physics2D.IgnoreLayerCollision(6, 13, false);
    }

    public void ChangeHealth(int amt)
    {
        if (amt < 0)
        {
            if (isInvincible || invRolling)
                return;

            isInvincible = true;
            invincibleTimer = hurtDelay;

            camController.StartCameraShake();
            lightScript.ChangeToRed();
            audioSource.Play();
            
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amt, 0, maxHealth);
        //UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }
    public void TriggerGameOver()
    {
        gameOver.Setup();
    }

    void createDust()
    {
        dust.Play();
    }
}
