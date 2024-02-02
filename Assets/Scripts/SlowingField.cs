using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingField : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Lifetime());
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.moveSpeed /= 2;
            player.slowed = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.moveSpeed *= 2;
            player.slowed = false;
        }
    }

    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

}
