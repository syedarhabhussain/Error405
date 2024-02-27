using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinProjectile : MonoBehaviour
{
    // public float speed;
    Vector2 random;
    // Start is called before the first frame update
    void Start()
    {
       random = new Vector2(Random.Range(-2f,2f), -1);
       // Debug.Log("asdf");
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(random * 5 * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
        Destroy(gameObject);
    }
}
