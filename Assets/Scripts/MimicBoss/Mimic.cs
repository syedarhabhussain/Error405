using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimic : MonoBehaviour
{

    public GameObject coinProjectile;
    Damageable dmg;
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
        for(int i=0; i<30; i++)
        {
            Instantiate(coinProjectile, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
