using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSky : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            var anim = player.GetComponent<Animator>();
            anim.SetBool("Falling", true);
            StartCoroutine(Delay(player));
            //player.currentHealth = 0;
        }
    }

    IEnumerator Delay(PlayerController player)
    {
        yield return new WaitForSeconds(1f);
        var anim = player.GetComponent<Animator>();
        anim.SetBool("Falling", false);
        anim.Play("Player_Idle");
        player.currentHealth -= 1;
        player.transform.position = player.savedCheckpoint;
        StopAllCoroutines();
    }
}
