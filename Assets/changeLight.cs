using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class changeLight : MonoBehaviour
{
    public Light2D globeLight;
    private Color originalColor;
    [SerializeField] public float duration;

    void Start()
    {
        originalColor = globeLight.color;
    }

    public void ChangeToRed()
    {

        StartCoroutine(ChangeColorForTime());
    }

    private IEnumerator ChangeColorForTime()
    {
        globeLight.color = Color.red;
        yield return new WaitForSeconds(duration);
        globeLight.color = originalColor;
    }
 
}
