using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Melee : MonoBehaviour
{

    public AudioClip audioClip;
    public Joystick joystick;
    private Vector2 joystickPosition;
    private Vector2 joystickPositionOrigin;
    public Animator meleeAnimator;
    public Transform attackPosition;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public float startTimeBtwAttack;
    public int damage;
    private string currentState;
    private float timeBtwAttack;
    private AudioSource audioSource;

    // Animation States
    const string Melee_Attack = "Prototype_SwordAnimationForMelee";
    const string Melee_Idle = "Prototype_SwordAnimationIdle";


    // Start is called before the first frame update
    void Start()
    {
        joystickPositionOrigin = new Vector2(0, 0);
        meleeAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    // Update is called once per frame
    void Update()
    {
        // Takes current Joystick position
        joystickPosition = new Vector2(joystick.Horizontal, joystick.Vertical);
        meleeAnimator.SetBool("isAttacking 0", false);

        if (timeBtwAttack <= 0)
        {

            // Checks if Joystick Handle is not in the middle
            if (joystickPosition.x != joystickPositionOrigin.x && joystickPosition.y != joystickPositionOrigin.y)
            {

                PlayMeleeAttackAnim();
                // Range that checks the position, attack range and the enemies within the circle
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatIsEnemies);
                //grab the health of enemy

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    audioSource.Play();
                    if (enemiesToDamage[i].GetComponent<Target_MainFunctions_Tutorial>())
                    {
                        // takes the script of the TUTORIAL TARGET within the circle to take 
                        if (enemiesToDamage[i].GetComponent<Target_MainFunctions_Tutorial>().health <= 1)
                        {
                            enemiesToDamage[i].GetComponent<Target_MainFunctions_Tutorial>().TakeDamage(damage); // duplicate this per enemy
                        }
                    }
                    else if (enemiesToDamage[i].GetComponent<Target_MainFunctions_S1>())
                    {
                        // takes the script of the BATTLE MODE TARGETS within the circle to take 
                        if (enemiesToDamage[i].GetComponent<Target_MainFunctions_S1>().health <= 1)
                        {
                            enemiesToDamage[i].GetComponent<Target_MainFunctions_S1>().TakeDamage(damage); // duplicate this per enemy
                        }
                    }
                    else if (enemiesToDamage[i].GetComponent<Target_MainFunctions_BossCoco>())
                    {
                        // takes the script of the BATTLE MODE TARGETS within the circle to take 
                        if (enemiesToDamage[i].GetComponent<Target_MainFunctions_BossCoco>().health <= 1)
                        {
                            enemiesToDamage[i].GetComponent<Target_MainFunctions_BossCoco>().TakeDamage(damage); // duplicate this per enemy
                        }
                    }


                }


            }
            // Makes the countdown come back
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;

        }


    }


    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        meleeAnimator.Play(newState);

        currentState = newState;
    }


    public void PlayMeleeAttackAnim()
    {
        meleeAnimator.SetTrigger("isAttacking");
    }
}
