using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubble : MonoBehaviour
{
    public float lifetime = 10f;
    GameObject player;
    public float hitRange;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (Vector2.Distance(transform.position, player.transform.position) <= hitRange)
        {
            player.GetComponent<PlayerController>().ChangeHealth(-1);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, hitRange);
    }

    // Update is called once per frame
    void Update()
    {
        if (lifetime <= 0)
            Destroy(gameObject);
        lifetime -= Time.deltaTime;
    }
}
