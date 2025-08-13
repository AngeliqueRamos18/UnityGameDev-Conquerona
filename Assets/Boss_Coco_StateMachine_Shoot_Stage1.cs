using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Coco_StateMachine_Shoot_Stage1 : StateMachineBehaviour
{
    [SerializeField]
    GameObject bullet_Boss;

    public float timer;
    public float minTime;
    public float maxTime;

    public float fireRate;
    float nextFire;
    private int randState;
    private Transform target;
    private Target_MainFunctions_BossCoco mainFunctions;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mainFunctions = GameObject.FindGameObjectWithTag("Boss_Coco").GetComponent<Target_MainFunctions_BossCoco>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        randState = Random.Range(0,2);
        timer = Random.Range(minTime, maxTime);       
        nextFire = Time.time;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        // Timer and Selects the next state to enter 
        if(timer <= 0)
        {
            switch(randState)
            {
                default:
                    break;
                case 0:
                    animator.SetTrigger("walk");
                    break;
                case 1:
                    animator.SetTrigger("dash");
                    break;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }


        if(Time.time > nextFire)
        {
            GameObject bulletCloneBoss_Snot = Instantiate(bullet_Boss, animator.transform.position, target.transform.rotation); 
            //Rigidbody2D bulletRigidBodyBoss_Snot = bulletCloneBoss_Snot.GetComponent<Rigidbody2D>();
            nextFire = Time.time + fireRate;
        }



    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

}
