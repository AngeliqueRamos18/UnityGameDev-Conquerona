using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target_MainFunctions_BossCoco : MonoBehaviour
{
    [SerializeField]
    public AudioClip audioClip;
    public int health = 30;
    public float speed;
    public bool isActiveCase;
    public Slider boss_Coco_HealthBar;
    private float initialSpeed;
    private float noSpeed;
    private Transform target;
    private Animator anim;

    public Animator black;
    public Animator victory;
    public static bool pause;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        audioSource = GameObject.FindGameObjectWithTag("Boss_Coco").GetComponent<AudioSource>();
        isActiveCase = true;
        initialSpeed = speed;
        noSpeed = 0;
        audioSource.clip = audioClip;
    }

    // Update is called once per frame
    void Update()
    {
        boss_Coco_HealthBar.value = health;

        Debug.Log("Boss Health: " + health);
        if(pause == true)
        {
            isActiveCase = false;
            speed = noSpeed;
        }
        else
        {
            isActiveCase = true;
            speed = initialSpeed;
        }


        // NEW ADDITION WHEN HEALTH IS HALF, CHANGE TO SECOND STAGE
        if (health <= 15)
        {
            anim.SetTrigger("Stage2");
        }


        // NEW ADDITION WHEN HEALTH IS 0, END FIGHT
        if (health <= 0)
        {
            anim.SetTrigger("StopFight");
            speed = noSpeed;
            StartCoroutine(EndBattle());
        }
        // IF POSSIBLE, ADD A COROUTINE TO FADE OUT THIS FIGHT

    }



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
/*            Destroy(hitInfo.gameObject);
*/        }
        // } else if (hitInfo.CompareTag("Melee"))
        // {

        // }
        Debug.Log("Player Trigger Damaged using: " + hitInfo.tag);
    }


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

    IEnumerator EndBattle()
    {
        yield return new WaitForSeconds(0.5f);
        victory.SetBool("victory", true);
        //Pwede magdagdag dito yung appearance ng victory text dito
        yield return new WaitForSeconds(5);
        black.SetBool("FadeOut", true);
    }
}
