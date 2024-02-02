using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    GameObject signMessage;
    GameObject eIndicator;
    [SerializeField] int screenNum;
    // Start is called before the first frame update
    void Start()
    {
        signMessage = GameObject.FindWithTag("Canvas").transform.GetChild(screenNum).gameObject;
        eIndicator = transform.GetChild(0).GetChild(0).gameObject;
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
            signMessage.SetActive(true);
            Time.timeScale = 0;
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
        {
            eIndicator.SetActive(false);
            signMessage.SetActive(false);
        }
    }

    public void exitButton()
    {
        signMessage.SetActive(false);
        Time.timeScale = 1;
    }
}
