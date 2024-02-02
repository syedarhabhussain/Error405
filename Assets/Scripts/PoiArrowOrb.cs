using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoiArrowOrb : MonoBehaviour
{
    public Sprite icon;
    PickUpScreen itemScreen;
    GameObject eIndicator;
    string UpgName, desc;
    // Start is called before the first frame update
    void Start()
    {
        itemScreen = GameObject.FindWithTag("Canvas").GetComponent<PickUpScreen>();
        eIndicator = transform.GetChild(0).GetChild(0).gameObject;
        UpgName = "Poison Arrow";
        desc = "Arrows deal poison damage over time";
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        Upgrades playerUp = other.gameObject.GetComponent<Upgrades>();
        if (player != null && Input.GetKeyDown(KeyCode.E))
        {
            itemScreen.Appear(UpgName, desc, icon);
            StartCoroutine(Decision(playerUp));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
            eIndicator.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
            eIndicator.SetActive(false);
    }

    IEnumerator Decision(Upgrades playerUp)
    {
        //Wait until a decision is made
        while (itemScreen.collected == 0)
            yield return null;

        //if the yes button is pressed
        if (itemScreen.collected == 1)
        {
            if (!playerUp.poiArrow)
            {
                playerUp.setPoiArrow(icon);
            }
            Destroy(gameObject);
        }
    }

}
