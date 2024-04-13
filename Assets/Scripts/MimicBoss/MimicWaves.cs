using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicWaves : StateMachineBehaviour
{
    Mimic boss;
    float timer;
    bool fired;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Idle");
        boss = animator.GetComponent<Mimic>();
        boss.RubbleFall();
        timer = 7f;
        fired = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer < 3 && !fired) 
        {
            boss.WaveAttack();
            fired = true;
        }
            
        if (timer <= 0)
        {
            animator.SetTrigger("Idle");
        }
        else
            timer -= Time.deltaTime;

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
