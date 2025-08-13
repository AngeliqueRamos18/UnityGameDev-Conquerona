using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Coco_StateMachine_Dash_Stage1 : StateMachineBehaviour
{
    [SerializeField]
    public AudioClip audioClip;
    public float timer;
    public float minTime;
    public float maxTime;
    public float addToSpeed;
    private float dashSpeed;
    private int randState;
    private Transform target;
    private Vector3 lastPos;
    private Target_MainFunctions_BossCoco mainFunctions;
    private TrailRenderer trailRenderer;

    private AudioSource audioSource;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mainFunctions = GameObject.FindGameObjectWithTag("Boss_Coco").GetComponent<Target_MainFunctions_BossCoco>();
        trailRenderer = GameObject.FindGameObjectWithTag("Boss_Coco").GetComponent<TrailRenderer>();
        audioSource = GameObject.FindGameObjectWithTag("Boss_Coco").GetComponent<AudioSource>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        randState = Random.Range(0, 2);
        timer = Random.Range(minTime, maxTime);
        trailRenderer.enabled = true;
        dashSpeed = mainFunctions.speed + addToSpeed;

        lastPos = target.transform.position;


        // to load audio of this animation clip
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        // Timer and Selects the next state to enter 
        if (timer <= 0)
        {
            switch (randState)
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
        else
        {
            timer -= Time.deltaTime;
        }


        //Dashing Ability
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, lastPos, dashSpeed * Time.deltaTime);
        if (animator.transform.position == lastPos)
        {
            audioSource.Play();
            lastPos = target.transform.position;
        }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        trailRenderer.enabled = false;
    }
}
