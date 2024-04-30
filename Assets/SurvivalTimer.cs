using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SurvivalTimer : MonoBehaviour
{
    // Start is called before the first frame update
    float currentTime;
    [SerializeField] TextMeshProUGUI timerText;

    void Start()
    {
        timerText = this.gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        timerText.text = Mathf.CeilToInt(currentTime).ToString();
    }
}
