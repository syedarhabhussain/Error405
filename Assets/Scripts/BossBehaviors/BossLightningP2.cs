using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLightningP2 : StateMachineBehaviour
{
    Boss info;
    Pathfinding.AIBase ai;
    float timer;
    float bossCurrHealth;
    float bossMaxHealth;
    public GameObject lightning;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Phase2");
        ai = animator.GetComponent<Pathfinding.AIBase>();
        ai.canMove = true;
        info = animator.GetComponent<Boss>();
        info.callLightning(lightning, 50);
        timer = 2;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossCurrHealth = animator.GetComponent<Damageable>().currentHealth;
        bossMaxHealth = animator.GetComponent<Damageable>().maxHealth;

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
