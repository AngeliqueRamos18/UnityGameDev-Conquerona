using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Scene_BattleModeFinal_Script : MonoBehaviour
{
    public List<string> sign1 = new List<string>();
    public List<string> sign2 = new List<string>();
    public List<string> sign3 = new List<string>();
    public List<string> sign4 = new List<string>();
    public List<string> sign5 = new List<string>();
    public static string eventConvo;
    public DialogManager_BattleModeFinal dialogManager;


    //For talk chat
    public string npcName;
    public bool startTalk;
    public PlayerMovement playerMovement;
    public static string collidedNPC;
    public Button read;

    void Start()
    {
        npcName = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRead()
    {
        if(read.interactable == true)
        {
            read.interactable = false;

            if (collidedNPC.Equals("BattleModeFinal_Signs"))
            {
                dialogManager.Start_Dialog(npcName, sign1);
            }
            else if (collidedNPC.Equals("BattleModeFinal_Signs2"))
            {
                dialogManager.Start_Dialog(npcName, sign2);
            }
            else if (collidedNPC.Equals("BattleModeFinal_Signs3"))
            {
                dialogManager.Start_Dialog(npcName, sign3);
            }
            else if (collidedNPC.Equals("BattleModeFinal_Signs4"))
            {
                dialogManager.Start_Dialog(npcName, sign4);
            }
            else if (collidedNPC.Equals("BattleModeFinal_Signs5"))
            {
                dialogManager.Start_Dialog(npcName, sign5);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collide)
    {
        //para hindi maulit ulit yung sinasabi ng frontliner 1 na cutscene
        if (collide.gameObject.CompareTag("BattleModeFinal_Signs"))
        {
            collidedNPC = "BattleModeFinal_Signs";
            read.interactable = true;

        }
        else if (collide.gameObject.CompareTag("BattleModeFinal_Signs2"))
        {
            collidedNPC = "BattleModeFinal_Signs2";
            read.interactable = true;

        }
        else if (collide.gameObject.CompareTag("BattleModeFinal_Signs3"))
        {
            collidedNPC = "BattleModeFinal_Signs3";
            read.interactable = true;

        }
        else if (collide.gameObject.CompareTag("BattleModeFinal_Signs4"))
        {
            collidedNPC = "BattleModeFinal_Signs4";
            read.interactable = true;

        }
        else if (collide.gameObject.CompareTag("BattleModeFinal_Signs5"))
        {
            collidedNPC = "BattleModeFinal_Signs5";
            read.interactable = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        collidedNPC = "";
        read.interactable = false;
    }
}
