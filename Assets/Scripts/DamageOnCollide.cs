using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
     //   Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Player")
        {
            //Debug.Log("hit");
            other.gameObject.transform.GetComponent<PlayerController>().ChangeHealth(-1);
        }
    }
}
