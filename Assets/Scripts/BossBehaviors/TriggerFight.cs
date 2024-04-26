using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFight : MonoBehaviour
{
    public GameObject boss;
    public CanvasGroup bossHealthBar;
    public bool mimicBoss;
    public Camera cam;
    public GameObject spike1;
    public GameObject spike2;
    public bool fightStart;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        Animator anim = boss.GetComponent<Animator>();
        bossHealthBar.alpha = 1;
        anim.SetTrigger("StartFight");
        fightStart = true;
        if(mimicBoss)
        {
            cam.orthographicSize = 8.0f;
            spike1.GetComponent<Animator>().SetBool("Up", true);
            spike2.GetComponent<Animator>().SetBool("Up", true);
        }
        
    }

}
