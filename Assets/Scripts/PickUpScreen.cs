using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PickUpScreen : MonoBehaviour
{
    GameObject screen;
    public int collected;
    TMP_Text textBox;
    private GameObject itemIcon;
    void Start()
    {
        screen = transform.GetChild(2).gameObject;
        textBox = screen.transform.GetChild(2).gameObject.GetComponent<TMP_Text>();
        itemIcon = screen.transform.GetChild(3).gameObject;
    }

    public void Appear(string name, string desc, Sprite icon)
    {
        textBox.text = "You found " + name + "!\n\n\n\n" + desc + "\nDo you want to pick it up?";
        itemIcon.GetComponent<Image>().sprite = icon;
        collected = 0;
        screen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Yes()
    {
        collected = 1;
        screen.SetActive(false);
        Time.timeScale = 1;
    }

    public void No()
    {
        collected = -1;
        screen.SetActive(false);
        Time.timeScale = 1;
    }
}
