using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Cutscene_0_InsideTheTent3_Script : MonoBehaviour
{
    public static int sequencing;
    public static string eventConvo;
    public static string npcName;
    public bool firstConversationEnd;
    public bool secondConversationEnd;
    public Animator black;
    public CutsceneDialogManager_InsideTheTent3 dialogManager;
    public List<string> conversation = new List<string>();
    public List<string> secondConversation = new List<string>();
    public GameObject dialogSystem;


    void Start()
    {
        npcName = "Veteran";
        eventConvo = "firstConversation";
        firstConversationEnd = false;
        secondConversationEnd = false;
        sequencing = 0;
        StartCoroutine(ShowFirstNarration());
    }

    // Update is called once per frame
    void Update()
    {
        if (eventConvo.Equals("secondConversation") && secondConversationEnd == false)
        {
            StartCoroutine(ShowSecondNarration());
            secondConversationEnd = true;
        }
    }
    public IEnumerator ShowFirstNarration()
    {
        yield return new WaitForSeconds(3);
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, conversation);
    }

    public IEnumerator ShowSecondNarration()
    {
        npcName = "Volunteer";
        yield return new WaitForSeconds(3);
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, secondConversation);
    }
}
