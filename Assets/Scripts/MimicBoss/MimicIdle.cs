using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicIdle : StateMachineBehaviour
{
    float timer;
    //int rand;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("CoinAttack");
        timer = 4f;
        //rand = Random.Range(0, 2);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            //Debug.Log("asdf");
            animator.SetTrigger("CoinAttack");
        }
        else
            timer -= Time.deltaTime;

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
