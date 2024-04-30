using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeInventoryUI : MonoBehaviour
{
    public GameObject player;
    Upgrades upg;
    private GameObject icon1;
    private GameObject icon2;
   // private GameObject icon3;
    private bool hasIcon2;
    private GameObject timerText1, timerText2, arrowLvText, abilityLvText;
    private float timer1, timer2 = 0;
    public Sprite emptyIcon;

    // Start is called before the first frame update
    void Start()
    {
        upg = player.GetComponent<Upgrades>();
        icon1 = transform.GetChild(0).gameObject;
        icon2 = transform.GetChild(1).gameObject;
        timerText1 = icon1.transform.GetChild(0).gameObject;
        timerText2 = icon2.transform.GetChild(0).gameObject;
        arrowLvText = icon1.transform.GetChild(1).gameObject;
        abilityLvText = icon2.transform.GetChild(1).gameObject;
        // icon3 = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(upg.arrow == "empty")
        {
            timerText1.SetActive(false);
            arrowLvText.SetActive(false);
        }
        else
        {
            timerText1.SetActive(true);
            arrowLvText.SetActive(true);
        }

        if (upg.ability == "empty")
        {
            timerText2.SetActive(false);
            abilityLvText.SetActive(false);
        }
        else
        {
            timerText2.SetActive(true);
            abilityLvText.SetActive(true);
        }

        timerText1.GetComponent<TMP_Text>().text = Mathf.CeilToInt(timer1).ToString();
        timerText2.GetComponent<TMP_Text>().text = Mathf.CeilToInt(timer2).ToString();
        arrowLvText.GetComponent<TMP_Text>().text = "Lv." + upg.upgLevelArrow;
        abilityLvText.GetComponent<TMP_Text>().text = "Lv." + upg.upgLevel;

        if (timer1 > 0 )
        {
            timer1 -= Time.deltaTime;
        }
        if (timer2 > 0)
        {
            timer2 -= Time.deltaTime;
        }

        if(timer1 <= 0)
        {
            icon1.GetComponent<Image>().sprite = emptyIcon;
            upg.resetArrow();
        }
        if (timer2 <= 0)
        {
            icon2.GetComponent<Image>().sprite = emptyIcon;
            upg.resetAbility();
        }
    }

    public void UpdateIcons(Sprite icon)
    {
      //  if (!hasIcon2)
       // {
            UpdateIcon2(icon);
       // }
      //  else
       //     UpdateIcon3(icon);
    }

    

    public void UpdateIcon1(Sprite icon)
    {
        icon1.GetComponent<Image>().sprite = icon;
        timer1 = 60;
    }

    public void UpdateIcon2(Sprite icon)
    {
        icon2.GetComponent<Image>().sprite = icon;
        timer2 = 60;
    }
    /*
    public void UpdateIcon3(Sprite icon)
    {
        icon3.GetComponent<Image>().sprite = icon;

    }*/
}
