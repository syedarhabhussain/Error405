using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LNBirdWarning : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject field;
    public float offsetY;
    public float duration;

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
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
        Instantiate(field, new Vector2(transform.position.x, transform.position.y+offsetY), Quaternion.identity);
    }
}
