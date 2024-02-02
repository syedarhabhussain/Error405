using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningCircle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject field;
    void Start()
    {
        StartCoroutine(Lifetime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        Instantiate(field, transform.position, Quaternion.identity);
    }
}
