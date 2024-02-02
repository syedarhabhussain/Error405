using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLightning : StateMachineBehaviour
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
        animator.ResetTrigger("Idle");
        ai = animator.GetComponent<Pathfinding.AIBase>();
        ai.canMove = false;
        info = animator.GetComponent<Boss>();
        info.callLightning(lightning, 30);
        timer = 4;
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

        if (bossCurrHealth <= bossMaxHealth / 2)
        {
            animator.SetTrigger("Shield");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
