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
    private GameObject timerText1, timerText2;
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
        // icon3 = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        timerText1.GetComponent<TMP_Text>().text = Mathf.CeilToInt(timer1).ToString();
        timerText2.GetComponent<TMP_Text>().text = Mathf.CeilToInt(timer2).ToString();

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
