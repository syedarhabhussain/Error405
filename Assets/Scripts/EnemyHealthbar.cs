using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    public Slider slider;
    CanvasGroup canvasGroup;
    public bool isTower;
    public bool isBoss;

    void Start()
    {
        canvasGroup = GetComponent <CanvasGroup>();
        if (!isTower )
        {
            canvasGroup.alpha = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {   
        if (!isTower)
        {
            if (slider.value < 1)
            {
                canvasGroup.alpha = 1;
            }
        }

        if (isBoss)
        {
            if (slider.value <= 0)
            {
                canvasGroup.alpha = 0;
            }
        }
    }

    public void UpdateHealthbar(float currHealth, float maxHealth)
    {
        slider.value = currHealth/maxHealth;
    }
}
