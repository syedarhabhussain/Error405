using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWarningCircle : MonoBehaviour
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
        Instantiate(field, new Vector2(transform.position.x, transform.position.y + 5.25f), Quaternion.identity);
    }
}
