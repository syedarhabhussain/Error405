using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public Sprite multiIcon;
    public Sprite pierceIcon;
    public Sprite expIcon;
    public Sprite poiIcon;
    public Sprite froIcon;
    public Sprite emptyIcon;

    public bool multiShot = false;
    public bool pierceShot = false;
    public bool expArrow = false;
    public bool poiArrow = false;
    public bool froArrow = false;
    string savedAbility;
    string savedArrow;
    public string ability;
    public string arrow;
    [SerializeField] UpgradeInventoryUI InvUI;
    // Start is called before the first frame update
    void Start()
    {
        savedAbility = PlayerPrefs.GetString("Ability", "");
        savedArrow = PlayerPrefs.GetString("Arrow", "");
        ability = savedAbility;
        arrow = savedArrow;
        if (ability == "Multishot")
            setMultiShot(multiIcon);
        if (ability == "Pierceshot")
            setPierceShot(pierceIcon);
        if (arrow == "ExpArrow")
            setExpArrow(expIcon);
        if (arrow == "PoiArrow")
            setPoiArrow(poiIcon);
        if (arrow == "FroArrow")
            setFroArrow(froIcon);
        if (arrow == "empty")
            resetArrow();
        if (ability == "empty")
            resetAbility();
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetArrow()
    {
        arrow = "empty";
        poiArrow = false;
        froArrow = false;
        expArrow = false;
    }

    public void resetAbility()
    {
        ability = "empty";
        pierceShot = false;
        multiShot = false;
    }

    public void setPierceShot(Sprite icon)
    {
        ability = "Pierceshot";
        pierceShot = true;
        multiShot = false;
        InvUI.UpdateIcons(icon);
    }

    public void setMultiShot(Sprite icon)
    {
        ability = "Multishot";
        multiShot = true;
        pierceShot = false;
        InvUI.UpdateIcons(icon);
    }

    public void setExpArrow(Sprite icon)
    {
        arrow = "ExpArrow";
        poiArrow = false;
        froArrow = false;
        expArrow = true;
        InvUI.UpdateIcon1(icon);
    }

    public void setPoiArrow(Sprite icon)
    {
        arrow = "PoiArrow";
        expArrow = false;
        froArrow = false;
        poiArrow = true;
        InvUI.UpdateIcon1(icon);
    }

    public void setFroArrow(Sprite icon)
    {
        arrow = "FroArrow";
        poiArrow = false;
        expArrow = false;
        froArrow = true;
        InvUI.UpdateIcon1(icon);
    }
}
