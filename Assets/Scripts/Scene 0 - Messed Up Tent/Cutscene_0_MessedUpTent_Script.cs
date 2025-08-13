using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Cutscene_0_MessedUpTent_Script : MonoBehaviour
{
    public static int sequencing;
    public static string eventConvo;
    public static string npcName;
    public static bool adventureMode;
    public bool firstConversationEnd;
    public Animator black;
    // Animators for cutscenes
    public Animator maria;

    //

    public CutsceneDialogManager_MessedUpTent dialogManager;
    public List<string> conversation = new List<string>();
    public List<string> chatMaria = new List<string>();
    public GameObject dialogSystem;

    //For trigger button chat
    public Button btnTalk;
    public bool startTalk;
    public PlayerMovement playerMovement;
    public static string collidedNPC;
    public bool talkMaria;

    void Start()
    {
        npcName = "Maria";
        eventConvo = "";
        firstConversationEnd = false;
        adventureMode = false;
        sequencing = 0;
        talkMaria = false;
        StartCoroutine(ShowFirstNarration());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public IEnumerator ShowFirstNarration()
    {
        eventConvo = "firstPart";
        yield return new WaitForSeconds(3);
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, conversation);
        maria.SetBool("Start_Concerned", true);
        talkMaria = true;
    }

    public void StartTalk()
    {
        if (btnTalk.interactable == true)
        {
            btnTalk.interactable = false;

            if (collidedNPC.Equals("NPC_Maria") && talkMaria == true)
            {
                npcName = "Maria";
                dialogManager.Start_Dialog(npcName, chatMaria);

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collide)
    {
        //para hindi maulit ulit yung sinasabi ng frontliner 1 na cutscene
        if (collide.gameObject.CompareTag("NPC_Maria"))
        {
            eventConvo = "chatMaria";
            //reveals the talk button
            btnTalk.interactable = true;
            npcName = "Maria";
            collidedNPC = "NPC_Maria";
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        btnTalk.interactable = false;
        collidedNPC = "";
    }
}

