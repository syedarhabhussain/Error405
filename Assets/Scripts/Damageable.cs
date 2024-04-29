using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Damageable : MonoBehaviour
{
    public float maxHealth;
    public float health { get { return currentHealth; } }
    public float currentHealth;
    public EnemyHealthbar healthbar;
    bool poisoned;
    bool icy;
    public bool isBoss;

    public bool poiRes, expRes, froRes;

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

    public void ChangeHealth(float amt, string damType)
    {
        if(!isBoss)
            ai.canMove = true;
        if ((poiRes && damType == "poison") || (expRes && damType == "explosion") || (froRes && damType == "frost")) { 
            amt /= 2;
           // gameObject.transform.GetChild(1).GetComponent<TMP_Text>().colors32.a = 1;
            StartCoroutine(resistFade(gameObject.transform.GetChild(0).GetChild(1).gameObject));
        }
        currentHealth = Mathf.Clamp(currentHealth + amt, 0, maxHealth);
        healthbar.UpdateHealthbar(currentHealth, maxHealth);
    }

    private IEnumerator resistFade(GameObject text)
    {
        text.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        text.SetActive(false);
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
        /*
            
        */

        SpriteRenderer rend = GetComponent<SpriteRenderer>();
        yield return new WaitForSeconds(1.5f);
        ChangeHealth((-0.5f * GameObject.FindWithTag("Player").GetComponent<Upgrades>().upgLevelArrow), "poison");  //deal damage multiplied by upgrade level
        rend.color = Color.green;
        yield return new WaitForSeconds(0.25f);
        rend.color = Color.white;

        yield return new WaitForSeconds(2f);
        ChangeHealth((-0.5f * GameObject.FindWithTag("Player").GetComponent<Upgrades>().upgLevelArrow), "poison");  //deal damage multiplied by upgrade level
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
        ai.maxSpeed *= 1 - (.15f * GameObject.FindWithTag("Player").GetComponent<Upgrades>().upgLevelArrow); //1 - (.15 * upglevelarrow)
        anim.speed = 1 - (.15f * GameObject.FindWithTag("Player").GetComponent<Upgrades>().upgLevelArrow);

        yield return new WaitForSeconds(3f);

        rend.color = Color.white;
        ai.maxSpeed = ogSpeed;
        anim.speed = 1f;
        icy = false;
    }

}
