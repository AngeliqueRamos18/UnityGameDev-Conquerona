using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Cutscene_0_BossFightOutro_Script : MonoBehaviour
{
    public static int sequencing;
    public static string eventConvo;
    public static string npcName;
    public bool firstConversationEnd;
    public bool secondConversationEnd;
    public bool thirdConversationEnd;
    public bool fourthConversationEnd;
    public Animator black;
    public CutsceneDialogManager_BossFightOutro dialogManager;
    public List<string> conversation = new List<string>();
    public List<string> secondConversation = new List<string>();
    public List<string> thirdConversation = new List<string>();
    public List<string> fourthConversation = new List<string>();
    public List<string> fifthConversation = new List<string>();
    public GameObject dialogSystem;

    void Start()
    {
        npcName = "Coco";
        eventConvo = "firstConversation";
        firstConversationEnd = false;
        secondConversationEnd = false;
        thirdConversationEnd = false;
        sequencing = 0;
        StartCoroutine(ShowFirstNarration());
    }

    // Update is called once per frame
    void Update()
    {
        if(eventConvo.Equals("secondConversation") && firstConversationEnd == false)
        {
            StartCoroutine(ShowSecondNarration());
            firstConversationEnd = true;
        }
        else if (eventConvo.Equals("thirdConversation") && secondConversationEnd == false)
        {
            StartCoroutine(ShowThirdNarration());
            secondConversationEnd = true;
        }
        else if (eventConvo.Equals("fourthConversation") && thirdConversationEnd == false)
        {
            StartCoroutine(ShowFourthNarration());
            thirdConversationEnd = true;
        }
        else if (eventConvo.Equals("fifthConversation") && fourthConversationEnd == false)
        {
            StartCoroutine(ShowFifthNarration());
            fourthConversationEnd = true;
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
        npcName = "Veteran";
        //Delay before starting the second dialogue
        yield return new WaitForSeconds(3);
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, secondConversation);
    }
    public IEnumerator ShowThirdNarration()
    {
        npcName = "Veteran";
        //Delay before starting the second dialogue
        yield return new WaitForSeconds(3);
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, thirdConversation);
    }

    public IEnumerator ShowFourthNarration()
    {
        npcName = "???";
        //Delay before starting the second dialogue
        yield return new WaitForSeconds(4);
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, fourthConversation);
    }
    public IEnumerator ShowFifthNarration()
    {
        npcName = "Veteran";
        //Delay before starting the second dialogue
        yield return new WaitForSeconds(3);
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, fifthConversation);
    }
}
