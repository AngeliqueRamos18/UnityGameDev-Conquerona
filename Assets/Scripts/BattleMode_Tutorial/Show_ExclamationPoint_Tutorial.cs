using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_ExclamationPoint_Tutorial : MonoBehaviour
{
    bool isShown;
    //public GameObject exclamationPoint;
    public Animator animator_ExclamationPoint;
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    private Target_MainFunctions_Tutorial target_MainFunctions_Tutorial;
    int targetHealth;

    void Start()
    {
        isShown = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        target_MainFunctions_Tutorial = gameObject.GetComponentInParent<Target_MainFunctions_Tutorial>();
        targetHealth = target_MainFunctions_Tutorial.health;
    }

    // Update is called once per frame
    void Update()
    {
        targetHealth = target_MainFunctions_Tutorial.health;
        switch(isShown)
        {
            default:
                break;
            case true: 
                spriteRenderer.enabled = true;
                animator_ExclamationPoint.SetTrigger("Trigger_ExclamationPoint");
                animator_ExclamationPoint.SetBool("Start_ExclamationPoint", true);
                //Insert dialogue for the use syringe tutorial
                BattleMode_Script.eventConvo = "secondPart";
                break;
            case false:
                spriteRenderer.enabled = false;
                animator_ExclamationPoint.SetBool("Start_ExclamationPoint", false);
                //none
                break;
        }

    // Shows itself when health is at 1
    if (targetHealth == 1)
    {
        isShown = true;
        Debug.Log("Use Syringe!");
    }    

    if (targetHealth == 0)
    {
        isShown = false;
        BattleMode_Script.eventConvo = "thirdPart";
        }

    // if(Input.GetKeyDown(KeyCode.Space))
    // {
    //     isShown = !isShown;
    // }


    }
}
