using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdle : StateMachineBehaviour
{
    Pathfinding.AIBase ai;
    float timer;
    int rand;
    float bossCurrHealth;
    float bossMaxHealth;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Spiral");
        animator.ResetTrigger("Lightning");
        ai = animator.GetComponent<Pathfinding.AIBase>();
        ai.canMove = false;
        timer = 4f;
        rand = Random.Range(0, 2);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossCurrHealth = animator.GetComponent<Damageable>().currentHealth;
        bossMaxHealth = animator.GetComponent<Damageable>().maxHealth;

        if (timer <= 0)
        {
            if (rand < 1)
                animator.SetTrigger("Lightning");
            else
                animator.SetTrigger("Spiral");
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
