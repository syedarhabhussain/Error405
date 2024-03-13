using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveProjectile : MonoBehaviour
{
    public float scaleSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //increase in length over time
        transform.localScale += Vector3.right * scaleSpeed * (Time.deltaTime/1.5f);
        //travel
        transform.Translate(new Vector2(0,-1) * 5 * Time.deltaTime/2);
    }
}
