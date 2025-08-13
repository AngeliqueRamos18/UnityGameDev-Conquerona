using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Cutscene_0_InsideTheTent_Script : MonoBehaviour
{
    public static int sequencing;
    public static string eventConvo;
    public static string npcName;
    public bool firstConversationEnd;
    public bool endSceneStopper;
    public Animator black;
    public CutsceneDialogManager_InsideTheTent dialogManager;
    public List<string> conversation = new List<string>();
    public List<string> bagTutorial = new List<string>();
    public GameObject dialogSystem;
    public GameObject dialogSystem2;
    public static bool cutsceneDone;

    public List<string> vetConversation = new List<string>();
    public static bool chatVeteran;
    public Button btnTalk;
    public string collidedNPC;

 

    void Start()
    {
        cutsceneDone = false;
        npcName = "Robert's Sister";
        eventConvo = "firstConversation";
        firstConversationEnd = false;
        endSceneStopper = false;
        sequencing = 0;
        StartCoroutine(ShowFirstNarration());
        collidedNPC = "";

        chatVeteran = false;

    }

    private void Update()
    {
        Debug.Log(cutsceneDone);
    }
    public IEnumerator ShowFirstNarration()
    {
        yield return new WaitForSeconds(3);
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, conversation);
        StartCoroutine(ShowBagTutorial());
    }

    public IEnumerator ShowBagTutorial()
    {
        yield return new WaitUntil(() => cutsceneDone == true);
        npcName = "Veteran";
        yield return new WaitForSeconds(0.1f);
        dialogSystem2.SetActive(true);
        dialogManager.Start_Dialog2(npcName, bagTutorial);
    }

    

    public void StartTalk()
    {
        if (btnTalk.interactable == true)
        {
            btnTalk.interactable = false; //Makes the btnTalk disappear after clicking on it
            if (collidedNPC.Equals("NPC_Veteran"))
            {
                StartCoroutine(ChatVeteran());
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.CompareTag("NPC_Veteran"))
        {
            btnTalk.interactable = true;
            npcName = "Veteran";
            collidedNPC = "NPC_Veteran";
            eventConvo = "chatVeteran";
        }
    }
    public void OnCollisionExit2D(Collision2D player)
    {
        btnTalk.interactable = false;
        collidedNPC = "";
    }

    public IEnumerator ChatVeteran()
    {
        npcName = "Veteran";
        yield return new WaitForSeconds(0.1f);
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, vetConversation);
    }
}
