using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Coco_StateMachine_Walk_Stage1 : StateMachineBehaviour
{
    public float timer;
    public float minTime;
    public float maxTime;
    private int randState;
    private Transform target;
    private Target_MainFunctions_BossCoco mainFunctions;
    private TrailRenderer trailRenderer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    
        trailRenderer = GameObject.FindGameObjectWithTag("Boss_Coco").GetComponent<TrailRenderer>();
        mainFunctions = GameObject.FindGameObjectWithTag("Boss_Coco").GetComponent<Target_MainFunctions_BossCoco>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        trailRenderer.enabled = false;
        randState = Random.Range(0,2);
        timer = Random.Range(minTime, maxTime);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(timer <= 0)
        {
            switch(randState)
            {
                default:
                    break;
                case 0:
                    animator.SetTrigger("dash");
                    break;
                case 1:
                    animator.SetTrigger("shoot");
                    break;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }


        animator.transform.position = Vector2.MoveTowards(animator.transform.position, target.position,  mainFunctions.speed * Time.deltaTime);       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
