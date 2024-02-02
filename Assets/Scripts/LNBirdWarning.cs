using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LNBirdWarning : MonoBehaviour
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
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        Instantiate(field, new Vector2(transform.position.x, transform.position.y+1.75f), Quaternion.identity);
    }
}
