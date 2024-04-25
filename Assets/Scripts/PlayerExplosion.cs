using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosion : MonoBehaviour
{ 
    private void Start()
    {
        StartCoroutine(ExplosionDelay());
        switch(GameObject.FindWithTag("Player").GetComponent<Upgrades>().upgLevelArrow)
        {
            case 1:
                Debug.Log("Explosion Size 1");
                transform.localScale = new Vector3(1.0f , 1.0f, 1.0f);
                break;
            case 2:
                Debug.Log("Explosion Size 1");
                transform.localScale = new Vector3(1.5f , 1.5f, 1.5f);
                break;
            case 3:
                Debug.Log("Explosion Size 1");
                transform.localScale = new Vector3(2.0f , 2.0f, 2.0f);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Damageable enemy = other.gameObject.GetComponent<Damageable>();
        if (enemy != null)
        {
            enemy.ChangeHealth(-1, "explosion");
        }
    }

    IEnumerator ExplosionDelay()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
