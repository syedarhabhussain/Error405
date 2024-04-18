using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject enemies;
    public GameObject levelLoader;
    private MainMenu menu;

    // Start is called before the first frame update
    void Start()
    {
        menu = levelLoader.GetComponent<MainMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        
        if (player != null && enemies.transform.childCount == 0)
        {
            Upgrades upg = player.GetComponent<Upgrades>();
            PlayerPrefs.SetString("Ability", upg.ability);
            PlayerPrefs.SetString("Arrow", upg.arrow);
            PlayerPrefs.SetInt("Health", player.currentHealth);
            PlayerPrefs.Save();
            menu.PlayGame();
        }
    }
}
