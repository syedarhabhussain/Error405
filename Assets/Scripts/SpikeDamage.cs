using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(SpikeUp());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    IEnumerator SpikeUp()
    {
        while (true)
        {
            anim.SetBool("Up", true);
            yield return new WaitForSeconds(2f);
            anim.SetBool("Up", false);
            yield return new WaitForSeconds(2f);
        }
    }

}
