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
        if(other.gameObject.name == "FeetHitbox")
        {
            other.gameObject.transform.parent.GetComponent<PlayerController>().ChangeHealth(-1);
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
