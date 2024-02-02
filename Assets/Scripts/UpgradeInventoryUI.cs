using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeInventoryUI : MonoBehaviour
{
    public GameObject player;
    Upgrades upg;
    private GameObject icon1;
    private GameObject icon2;
   // private GameObject icon3;
    private bool hasIcon2;
    // Start is called before the first frame update
    void Start()
    {
        upg = player.GetComponent<Upgrades>();
        icon1 = transform.GetChild(0).gameObject;
        icon2 = transform.GetChild(1).gameObject;
       // icon3 = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

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

    }

    public void UpdateIcon2(Sprite icon)
    {
        icon2.GetComponent<Image>().sprite = icon;

    }
    /*
    public void UpdateIcon3(Sprite icon)
    {
        icon3.GetComponent<Image>().sprite = icon;

    }*/
}
