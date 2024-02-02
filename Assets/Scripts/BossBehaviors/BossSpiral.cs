using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpiral : StateMachineBehaviour
{
    Boss info;
    public GameObject lightningOrb;
    Pathfinding.AIBase ai;
    float timer;
    float bossCurrHealth;
    float bossMaxHealth;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Idle");
        ai = animator.GetComponent<Pathfinding.AIBase>();
        info = animator.GetComponent<Boss>();
        ai.canMove = false;
        info.callBulletSpiral(lightningOrb, .2f);
        timer = 5;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossCurrHealth = animator.GetComponent<Damageable>().currentHealth;
        bossMaxHealth = animator.GetComponent<Damageable>().maxHealth;

        if (timer <= 0)
        {
            info.cancelSpiral();
            ai.canMove = true;

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
        info.cancelSpiral();
    }
}
