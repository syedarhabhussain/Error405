using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePuddle : MonoBehaviour
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

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "FeetHitbox")
        {
            other.gameObject.transform.parent.GetComponent<PlayerController>().ChangeHealth(-1);
        }
    }

    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

}
