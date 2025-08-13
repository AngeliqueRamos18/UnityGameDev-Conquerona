using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Coco_StateMachine_Enraged_Stage1 : StateMachineBehaviour
{
    private int rand;
    private Transform bossTransform;
    private Vector2 downPos;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossTransform = GameObject.FindGameObjectWithTag("Boss_Coco").GetComponent<Transform>();
        downPos = bossTransform.position + Vector3.down;
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, downPos,  1 * Time.deltaTime);
        rand = Random.Range(0,2);
        switch(rand)
        {
            default:
                break;
            case 0:
                animator.SetTrigger("walk");
                break;
            case 1:
                animator.SetTrigger("shoot");
                break;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
