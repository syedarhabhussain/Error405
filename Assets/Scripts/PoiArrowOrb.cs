using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoiArrowOrb : MonoBehaviour
{
    public Sprite icon;
    PickUpScreen itemScreen;
    GameObject eIndicator;
    string UpgName, desc;
    float interactRange = 0.8f;
    Transform playerT;
    // Start is called before the first frame update
    void Start()
    {
        playerT = GameObject.FindWithTag("Player").transform;
        itemScreen = GameObject.FindWithTag("Canvas").GetComponent<PickUpScreen>();
        eIndicator = transform.GetChild(0).GetChild(0).gameObject;
        UpgName = "Poison Arrow";
        desc = "Arrows deal .5 poison damage per stack (max 3) over time";
    }

    // Update is called once per frame
    void Update()
    {
        //if player is in range
        if (Vector2.Distance(transform.position, playerT.position) <= interactRange)
        {
            //set e indicator to be visible
            eIndicator.SetActive(true);

            //if e is pressed while in range
            if (Input.GetKeyDown(KeyCode.E))
            {
                //open decision screen
                itemScreen.Appear(UpgName, desc, icon);
                StartCoroutine(Decision(GameObject.FindWithTag("Player").GetComponent<Upgrades>()));
            }
        }
        else
        {
            eIndicator.SetActive(false);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactRange);
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
		        GameObject.FindWithTag("Player").GetComponent<Upgrades>().upgLevelArrow = 1;
            }
	        else if(playerUp.poiArrow)  //else if you do have the upgrade, upgrade level goes up if below level 3
	        {
		        if(GameObject.FindWithTag("Player").GetComponent<Upgrades>().upgLevelArrow < 3)
			        GameObject.FindWithTag("Player").GetComponent<Upgrades>().upgLevelArrow += 1;
	        }
            Destroy(gameObject);
        }
    }

}
