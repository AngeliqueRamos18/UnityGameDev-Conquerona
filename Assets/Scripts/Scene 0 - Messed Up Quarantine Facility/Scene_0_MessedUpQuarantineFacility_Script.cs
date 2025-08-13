using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Scene_0_MessedUpQuarantineFacility_Script : MonoBehaviour
{
    public static int sequencing;
    public static string eventConvo;
    public static string npcName;
    public bool talkVeteran;
    public bool firstConversationEnd;
    public Animator black;
    //Animators
    public Animator veteran;

    //
    public SceneDialogManager_MessedUpQuarantineFacility dialogManager;
    public List<string> conversation = new List<string>();
    public List<string> chatVet = new List<string>();
    public GameObject dialogSystem;

    public Button btnTalk;
    public bool startTalk;
    public PlayerMovement playerMovement;
    public static string collidedNPC;
    void Start()
    {
        
        
        eventConvo = "firstPart";
        firstConversationEnd = false;
        sequencing = 0;
        //bool variable if player is talking to Veteran
        talkVeteran = false;
    }

    private void Update()
    {
        /*//The dialogue should be activated only when Kael has talked to veteran
        if (talkVeteran == true && firstConversationEnd == false)
        {
            StartCoroutine(ShowFirstNarration());
            firstConversationEnd = true;
        }*/
    }

    public IEnumerator ShowFirstNarration()
    {
        eventConvo = "firstPart";
        npcName = "Veteran";
        yield return new WaitForSeconds(1);
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, conversation);
        veteran.SetBool("Start_Talk",true);
    }

    public void StartTalk()
    {
        if (btnTalk.interactable == true)
        {
            btnTalk.interactable = false;

            if (collidedNPC.Equals("NPC_Veteran") && talkVeteran == false)
            {
                npcName = "Veteran";
                dialogManager.Start_Dialog(npcName, conversation);
                talkVeteran = true;
            }
            else if(collidedNPC.Equals("NPC_Veteran") && talkVeteran == true)
            {
                dialogManager.Start_Dialog(npcName, chatVet);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collide)
    {
        //para hindi maulit ulit yung sinasabi ng frontliner 1 na cutscene
        if (collide.gameObject.CompareTag("NPC_Veteran"))
        {
            if(talkVeteran == true)
            {
                eventConvo = "chatVet";
                btnTalk.interactable = true;
                npcName = "Veteran";
                collidedNPC = "NPC_Veteran";
            }
            
            //reveals the talk button
            btnTalk.interactable = true;
            npcName = "Veteran";
            collidedNPC = "NPC_Veteran";
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        btnTalk.interactable = false;
        collidedNPC = "";
    }
}
