using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDamageText : MonoBehaviour
{
    public float timeAppear = 0.5f;
    public float floatSpeed = 50;
    public Vector3 floatDirection = new Vector3(0, 1, 0);
    public TextMeshPro textMesh;
    RectTransform rTransform;
    float timeElapsed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
        rTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        rTransform.position += floatDirection * floatSpeed * Time.deltaTime;

        if(timeElapsed > timeAppear)
        {
            Destroy(gameObject);
        }
    }
}
