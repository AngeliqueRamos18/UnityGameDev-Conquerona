using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_MainFunctions_S1 : MonoBehaviour
{
    // For Audio
    public AudioClip targetShoot;
    public AudioClip targetDash;
    public AudioClip targetWalk;
    public AudioClip targetCured;

    private AudioSource audioSource;
    //
    public int health = 10;
    public float speed;
    public float enemyDamage;
    public float enemyType;
    public float stoppingDistance;
    private Transform target;
    public float targetRange;
    public Animator target_Animator; //Change variableName to Animator
    public Transform[] moveSpots;
    public int randomSpot;
    private float waitTime;
    public float startWaitTime;
    private string currentState;

    public float attackStartTime;
    public float attackWaitTime;
    public Vector2 startingPos;
    public Vector2 exitPos;

    public basicEnemyStates currentEnemyState;
    SpriteRenderer spriteRenderer;

    public bool isActiveCase;


    // For shooting Target
    public float fireRate;
    float nextFire;

    [SerializeField]
    GameObject bullet_Target;

    // For Dashing Target

    public float addToSpeed;
    private float dashSpeed;
    private Vector3 lastPos;
    private TrailRenderer trailRenderer;

    // Animation States
    const string targetAC_Idle = "target_Animator_ActiveCase_Idle";
    const string targetAC_Chase = "target_Animator_ActiveCase_Walk";
    const string targetAC_Patrol = "target_Animator_ActiveCase_Patrol";
    const string targetAC_BackToStart = "target_Animator_ActiveCase_BackToStart";
    const string targetRC_RecoveringCase = "target_Animator_RecoveringCase";
    const string targetRC_Walk = "target_Animator_RecoveringCase_Walk";

    //Codes by angel
    public static bool pause;
    public Transform player;
    public static bool isColliding;
    //

    public enum basicEnemyStates
    {
        Idle,
        Chase,
        Patrol,
        Attack,
        BackToStart,
        Exit,

    }

    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentEnemyState = basicEnemyStates.Patrol;
        isActiveCase = true;
        startingPos = transform.position;
        exitPos = GameObject.Find("Exit Spot").transform.position;

        //code by angel
        pause = false;
        //

        // For shooting
        nextFire = Time.time;

        // For QuickChasing
        trailRenderer = GetComponent<TrailRenderer>();
        dashSpeed = speed + addToSpeed;
        trailRenderer.enabled = false;

        // For audio
        audioSource = GetComponent<AudioSource>();

    }


    // Update is called once per frame
    void Update()
    {
        //Testing code for enemies not pushing the player
        /*if(isColliding == true)
        {
            speed = 0f;
        }
        else
        {
            speed = 2f;
        }
*/
        //Test code by angel
        if (pause == true)
        {
            isActiveCase = false;
            speed = 0f;

        }
        else
        {
            isActiveCase = true;
            speed = 2f;
        }

        // /////////////////////////////

        // If the health is 0, remove access to ActiveCase Enemy States
        if (health <= 0)
        {
            isActiveCase = false;
            target_Animator.SetTrigger("CuredTrigger");
            speed = 0f;
            trailRenderer.enabled = false;
        }

        if (isActiveCase == true)
        {
            // Switch Enemy State Machine
            switch (currentEnemyState)
            {
                default:

                // For Patrol State
                case basicEnemyStates.Patrol:

                    transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
                    ChangeAnimationState(targetAC_Patrol);

                    // Idle during patrol
                    if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 1f)
                    {
                        if (waitTime <= 0)
                        {
                            randomSpot = Random.Range(0, moveSpots.Length);
                            waitTime = startWaitTime;
                            Debug.Log("Should be Moving");
                            target_Animator.SetBool("Start_Idle", false);
                            speed = 2f;
                        }
                        else
                        {
                            speed = 0f;
                            Debug.Log("Reducing Time");
                            waitTime -= Time.deltaTime;
                            target_Animator.SetBool("Start_Idle", true);
                            //ChangeAnimationState(targetAC_Idle);
                        }

                    }

                    FindTarget();
                    Debug.Log("Finding Target");
                    break;

                // For Chase State    
                case basicEnemyStates.Chase:
                    // Audio for walking
                    speed = 2f;
                    ChangeAnimationState(targetAC_Chase);
                    speed = 2f;

                    //Problem it applies to all of the enemy's movement
                    /*if(isColliding == true)
                    {
                        transform.position = Vector2.MoveTowards(transform.position, target.position, 0);
                    }
                    else if(isColliding == false)
                    {
                        speed = 2f;
                        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    }*/
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    TargetIsFarCheck();
                    AttackTarget();
                    break;

                // For Idle State    
                case basicEnemyStates.Idle:
                    ChangeAnimationState(targetAC_Idle);
                    break;

                // To return to Starting Position    
                case basicEnemyStates.BackToStart:
                    ChangeAnimationState(targetAC_BackToStart);
                    transform.position = Vector2.MoveTowards(transform.position, startingPos, speed * Time.deltaTime);
                    Debug.Log("BackToStart");
                    ReturnedToStart();
                    break;

                case basicEnemyStates.Attack:
                    //lastPos = target.transform.position;
                    switch (enemyType)
                    {
                        default:
                            Debug.Log("ATTACKING Normal");
                            break;
                        // For Shooting Enemy
                        case (1):
                            Debug.Log("ATTACKING SHOOT");
                            audioSource.clip = targetShoot;
                            if (Time.time > nextFire)
                            {
                                GameObject bulletCloneTarget_Snot = Instantiate(bullet_Target, transform.position, target.transform.rotation);
                                nextFire = Time.time + fireRate;
                                audioSource.volume = 0.5f;
                                audioSource.Play();
                            }
                            break;
                        // For QuickChasing Enemy
                        case (2):
                            Debug.Log("ATTACKING Quick Chase");
                            audioSource.clip = targetDash;
                            trailRenderer.enabled = true;
                            lastPos = target.transform.position;
                            transform.position = Vector2.MoveTowards(transform.position, lastPos, dashSpeed * Time.deltaTime);
                            if (transform.position == lastPos)
                            {
                                lastPos = target.transform.position;
                            }
                            break;
                    }
                    FindTarget();
                    break;
            }
        }
        //else modified by angel
        else if (isActiveCase == false && pause != true)
        {
            // Switches to this switch case when enemy is RecoveringCase
            switch (currentEnemyState)
            {
                default:

                // Exits the current scene by deleting itself
                case basicEnemyStates.Exit:

                    Debug.Log("Exit");
                    target_Animator.SetBool("Start_Cured", true);
                    speed = 1f;
                    transform.position = Vector2.MoveTowards(transform.position, exitPos, speed * Time.deltaTime);
                    Destroy(gameObject, 2.3f);
                    //ReachedToExit();
                    break;
            }
        }

    }



    //Function by Angel
    public void Unpause()
    {
        pause = false;
    }

    public void Pause()
    {
        pause = true;
    }
    ///   ================================
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Note: Switch Case to see which Enemy gets hit
        // Gets the functions of the enemy script 

        if (hitInfo.CompareTag("bullet"))
        {
            BulletShoot bullet = hitInfo.GetComponent<BulletShoot>();
            int bulletDamage = bullet.bulletDmg;
            Debug.Log(bulletDamage);

            if (health > 1)
            {
                TakeDamage(bulletDamage);
            }
            //Destroy(hitInfo.gameObject);
        }
        // } else if (hitInfo.CompareTag("Melee"))
        // {

        // }
        Debug.Log("Player Trigger Damaged using: " + hitInfo.tag);
    }


    //Enemy Takes Damage Method
    public void TakeDamage(int damage)
    {
        // Reduces Health by the damage of the player
        health -= damage;
        // Creates a new color that allows the red of the shader to appear 
        // gives it to the the MaterialTint_Damaged Script
        Color color = new Color(1, 0, 0, 1f);
        GetComponent<MaterialTint_Damaged>().SetTintColor(color);
        Debug.Log("Damage Taken " + damage);
    }

    // Enemy Finds Player Method
    private void FindTarget()
    {
        float targetRange = 5f;
        if (Vector2.Distance(transform.position, target.position) < targetRange)
        {
            currentEnemyState = basicEnemyStates.Chase;
        }
    }

    // Enemy Attacks Player
    private void AttackTarget()
    {
        float attackRange = 4f;
        if (Vector2.Distance(transform.position, target.position) < attackRange)
        {
            currentEnemyState = basicEnemyStates.Attack;
        }
    }

    // Enemy Check if they are far from the player
    private void TargetIsFarCheck()
    {
        float stopChaseDistance = 7f;
        if (Vector2.Distance(transform.position, target.position) > stopChaseDistance)
        {
            currentEnemyState = basicEnemyStates.BackToStart;
            ChangeAnimationState(targetAC_BackToStart);

        }
    }

    // Enemy Check if they have reached the starting Position
    private void ReturnedToStart()
    {
        float reachedPositionDistance = 2f;
        if (Vector2.Distance(transform.position, startingPos) < reachedPositionDistance)
        {
            currentEnemyState = basicEnemyStates.Patrol;
            ChangeAnimationState(targetAC_Patrol);
            trailRenderer.enabled = false;
        }
    }

    // RecoveringCase Enemy checks if they reached the exit Position
    private void ReachedToExit()
    {
        float reachedExitPosition = 1f;
        if (Vector2.Distance(transform.position, exitPos) < reachedExitPosition)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        target_Animator.Play(newState);

        currentState = newState;
    }


    //Testing for the enemies not pushing the player
    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.CompareTag("Player"))
        {
            isColliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D enemy)
    {
        if (enemy.gameObject.CompareTag("Player"))
        {
            isColliding = false;
        }
    }


}
