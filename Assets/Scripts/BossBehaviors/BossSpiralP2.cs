using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpiralP2 : StateMachineBehaviour
{
    public GameObject lightningOrb;
    Boss info;
    float timer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Idle");
        Debug.Log("how");
        info = animator.GetComponent<Boss>();
        info.callBulletSpiral(lightningOrb, .1f);
        timer = 4;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            info.cancelSpiral();

            animator.SetTrigger("Idle");
        }
        else
            timer -= Time.deltaTime;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        info.cancelSpiral();
    }
}
