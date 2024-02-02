using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BossShieldPhase : StateMachineBehaviour
{
    public GameObject shield;
    public GameObject pillar;
    Pathfinding.AIBase ai;
    List<GameObject> shieldPillars;
    Boss info;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ai = animator.GetComponent<Pathfinding.AIBase>();
        info = animator.GetComponent<Boss>();
        ai.canMove = false;
        Instantiate(shield, animator.transform.position, Quaternion.identity);
        Instantiate(pillar, new Vector2(154f, -40.25f), Quaternion.identity);
        Instantiate(pillar, new Vector2(168f, -40.25f), Quaternion.identity);
        Instantiate(pillar, new Vector2(154f, -48.25f), Quaternion.identity);
        Instantiate(pillar, new Vector2(168f, -48.25f), Quaternion.identity);
        info.callSpawns();
        //shieldPillars = new List<GameObject>( GameObject.FindGameObjectsWithTag("Pillar") );
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        shieldPillars = new List<GameObject>(GameObject.FindGameObjectsWithTag("Pillar"));
        if (shieldPillars.Count == 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Shield"));
            info.cancelSpawns();
            animator.SetTrigger("Phase2");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ai.canMove = true;
    }

    
}
