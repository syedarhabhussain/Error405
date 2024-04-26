using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimic : MonoBehaviour
{

    public GameObject coinProjectile;
    public GameObject potionProjectile;
    public GameObject waveProjectile;
    public GameObject warningCircle;
    Damageable dmg;
    public int coinAmt = 30;
    public List<GameObject> minions;
    public bool spawn1, spawn2;
    public GameObject spikes1, spikes2;
    // Start is called before the first frame update
    void Start()
    {
        GoldCoins();
        dmg = GetComponent<Damageable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dmg.currentHealth <= 0)
        {
            Destroy(gameObject); 
            spikes1.GetComponent<Animator>().SetBool("Up", false);
            spikes2.GetComponent<Animator>().SetBool("Up", false);
        }
        //Spawn after a third of health is missing
        if(dmg.currentHealth <= dmg.maxHealth / 3 * 2 && !spawn1)
        {
            SpawnMinions();
            spawn1 = true;
        }
        //Spawn after 2/3 of health is missing
        if (dmg.currentHealth <= dmg.maxHealth / 3 && !spawn2)
        {
            SpawnMinions();
            spawn2 = true;
        }
            
    }

    public void CallCoins()
    {
        StartCoroutine(GoldCoins());
    }

    IEnumerator GoldCoins()
    {
        for(int i=0; i<coinAmt; i++)
        {
            if (i == coinAmt / 2)
                Instantiate(potionProjectile, transform.position, Quaternion.identity);
            Instantiate(coinProjectile, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void WaveAttack()
    {
        for(int i=0; i<20; i++)
        {
            Quaternion waveRotation = Quaternion.Euler(0f, 0f, 0 + i * 18f);
            Instantiate(waveProjectile, transform.position, waveRotation);
        }
    }

    public void RubbleFall()
    {
        for(int i=0; i<2; i++)
        {
            Instantiate(warningCircle, new Vector2(Random.Range(455, 475), Random.Range(-47, -42)), Quaternion.identity);
        }
    }
    
    void SpawnMinions()
    {
        //Little slimes
        for(int i=0; i<7; i++)
        {
            GameObject mob = Instantiate(minions[Random.Range(2, minions.Count)], new Vector2(Random.Range(453, 475), Random.Range(-47, -42)), Quaternion.identity);
            mob.GetComponent<Pathfinding.AIBase>().canMove = true;
            mob.GetComponent<BossCheckpoint>().enabled = false;
        }
        //Big slime
        for (int i = 0; i < 2; i++)
        {
            GameObject mob = Instantiate(minions[0], new Vector2(Random.Range(453, 475), Random.Range(-47, -42)), Quaternion.identity);
            mob.GetComponent<Pathfinding.AIBase>().canMove = true;
            mob.GetComponent<BossCheckpoint>().enabled = false;
        }
        GameObject cSlime = Instantiate(minions[1], new Vector2(Random.Range(453, 475), Random.Range(-47, -42)), Quaternion.identity);
        cSlime.GetComponent<Pathfinding.AIBase>().canMove = true;
        cSlime.GetComponent<BossCheckpoint>().enabled = false;
    }
}
