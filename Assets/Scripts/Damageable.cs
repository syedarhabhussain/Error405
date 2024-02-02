using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float maxHealth;
    public float health { get { return currentHealth; } }
    public float currentHealth;
    public EnemyHealthbar healthbar;
    bool poisoned;
    bool icy;
    public bool isBoss;

    Pathfinding.AIBase ai;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        if (!isBoss)
        {
            healthbar = GetComponentInChildren<EnemyHealthbar>();
            healthbar.UpdateHealthbar(health, maxHealth);
        }
        ai = GetComponent<Pathfinding.AIBase>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHealth(float amt)
    {
        if(!isBoss)
            ai.canMove = true;
        currentHealth = Mathf.Clamp(currentHealth + amt, 0, maxHealth);
        healthbar.UpdateHealthbar(currentHealth, maxHealth);
    }

    public void setPoison()
    {
        if (!poisoned)
        {
            poisoned = true;
            StartCoroutine(Poisoned());
        }
    }

    public IEnumerator Poisoned()
    {
        SpriteRenderer rend = GetComponent<SpriteRenderer>();
        yield return new WaitForSeconds(1.5f);
        ChangeHealth(-0.5f);
        rend.color = Color.green;
        yield return new WaitForSeconds(0.25f);
        rend.color = Color.white;

        yield return new WaitForSeconds(2f);
        ChangeHealth(-0.5f);
        rend.color = Color.green;
        yield return new WaitForSeconds(0.25f);
        rend.color = Color.white;

        poisoned = false;
    }

    public void setFrost()
    {
        if (!icy)
        {
            icy = true;
            StartCoroutine(Frosted());
        }
    }

    IEnumerator Frosted()
    {
        SpriteRenderer rend = GetComponent<SpriteRenderer>();
        Animator anim = GetComponent<Animator>();
        rend.color = Color.cyan;
        float ogSpeed = ai.maxSpeed;
        ai.maxSpeed /= 2;
        anim.speed = 0.5f;

        yield return new WaitForSeconds(3f);

        rend.color = Color.white;
        ai.maxSpeed = ogSpeed;
        anim.speed = 1f;
        icy = false;
    }

}
