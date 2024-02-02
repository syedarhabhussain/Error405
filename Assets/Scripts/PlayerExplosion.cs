using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosion : MonoBehaviour
{ 
    private void Start()
    {
        StartCoroutine(ExplosionDelay());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Damageable enemy = other.gameObject.GetComponent<Damageable>();
        if (enemy != null)
        {
            enemy.ChangeHealth(-1);
        }
    }

    IEnumerator ExplosionDelay()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
