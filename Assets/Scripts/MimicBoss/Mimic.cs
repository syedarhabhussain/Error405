using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimic : MonoBehaviour
{

    public GameObject coinProjectile;
    public GameObject waveProjectile;
    Damageable dmg;
    public int coinAmt = 30;
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
}
