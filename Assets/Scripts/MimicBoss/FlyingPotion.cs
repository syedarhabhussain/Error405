using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPotion : MonoBehaviour
{
    Vector2 random;
    // Start is called before the first frame update
    void Start()
    {
        random = new Vector2(Random.Range(-2f, 2f), -1);
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 movement = new Vector3(random.x, 0, random.y);
        // movement = transform.TransformDirection(movement);
        // transform.Translate(movement.normalized * 3 * Time.deltaTime, Space.World);
        transform.Translate(random.normalized * 3 * Time.deltaTime, Space.World);
       // transform.Rotate(Vector3.forward * 30 * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ChangeHealth(1);  
        }
        if(other.gameObject.layer != 11)
            Destroy(gameObject);
    }
}
