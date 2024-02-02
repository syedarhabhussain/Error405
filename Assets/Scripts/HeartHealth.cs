using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartHealth : MonoBehaviour
{
    private int health;
    private int maxHealth;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] heartSprites;

    public PlayerController player;

    void Start()
    {
    
    }

    private void Update()
    {
        health = player.currentHealth;
        maxHealth = player.maxHealth;

        for ( int i = 0; i < heartSprites.Length; i++ )
        {
            if(i < health)
            {
                heartSprites[i].sprite = fullHeart;
            }
            else
            {
                heartSprites[i].sprite = emptyHeart;
            }

            if (i < maxHealth)
            {
                heartSprites[i].enabled = true;
            }
            else
            {
                heartSprites[i].enabled = false;
            }
        }
    }
}
