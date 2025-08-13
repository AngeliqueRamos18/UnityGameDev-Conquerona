using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject player;
    public static string npcName;
    public static string collidedNPC;
    public DialogManager dialogManager;
    public List<string> npc_Police1 = new List<string>();
    public List<string> npc_Police2 = new List<string>();
    public List<string> npc_Frontliner1 = new List<string>();
    public List<string> npc_Sign1 = new List<string>();
    public PlayerMovement playerMovement;
    public Button btnTalk;
    public GameObject walking;
    public bool startTalk;

    public void Start()
    {
        btnTalk = GameObject.Find("btnTalk").GetComponent<Button>();
        playerMovement = walking.GetComponent<PlayerMovement>();
        startTalk = false;
        npcName = "";
        collidedNPC = "";
    }

    private void Update()
    {
      
    }


    //public void OnMouseDown() // starts dialog by clicking on object
    //{
    //    dialogManager.Start_Dialog(npcName, npcConvo);
    //}
    public void OnCollisionEnter2D(Collision2D collide) // starts dialog by colliding with object
    {
        

        if (collide.gameObject.CompareTag("NPC_Police1"))
        {
            btnTalk.interactable = true;
            npcName = "Police";
            collidedNPC = "NPC_Police1";
        }
        else if (collide.gameObject.CompareTag("NPC_Police2"))
        {
            btnTalk.interactable = true;
            npcName = "Police 2";
            collidedNPC = "NPC_Police2";

            //Responsible for setting the scene switch script to activate after the dialog
            Debug.Log("Colliding!");
        }
        else if (collide.gameObject.CompareTag("NPC_Frontliner1"))
        {
            btnTalk.interactable = true;
            npcName = "Frontliner Jessie";
            collidedNPC = "NPC_Frontliner1";
        }
        else if (collide.gameObject.CompareTag("NPC_Sign1"))
        {
            btnTalk.interactable = true;
            npcName = "Sign";
            collidedNPC = "NPC_Sign1";
        }
        /*dialogManager.Start_Dialog(npcName, npcConvo);*/  
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        btnTalk.interactable = false;
        collidedNPC = "none";
    }

    public void StartTalk()
    {
       if(btnTalk.interactable == true)
        {
            if (collidedNPC.Equals("NPC_Police1"))
            {
                dialogManager.Start_Dialog(npcName, npc_Police1);
            }
            else if (collidedNPC.Equals("NPC_Police2"))
            {
                dialogManager.Start_Dialog(npcName, npc_Police2);
            }
            else if (collidedNPC.Equals("NPC_Frontliner1"))
            {
                dialogManager.Start_Dialog(npcName, npc_Frontliner1);
            }
            else if (collidedNPC.Equals("NPC_Sign1"))
            {
                dialogManager.Start_Dialog(npcName, npc_Sign1);
            }
            else
            {
                Debug.Log("No collided person!");
            }
        }
    }
}
