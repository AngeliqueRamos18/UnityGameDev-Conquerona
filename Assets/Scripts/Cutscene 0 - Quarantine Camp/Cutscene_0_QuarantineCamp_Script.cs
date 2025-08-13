using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Cutscene_0_QuarantineCamp_Script : MonoBehaviour
{
    public static int sequencing;
    public static string eventConvo;
    public static string npcName;
    public bool firstConversationEnd;
    public bool secondConversationEnd;
    public bool endSceneStopper;
    public Animator black;
    public CutsceneDialogManager_QuarantineCamp dialogManager;
    public List<string> conversation = new List<string>();
    public List<string> secondConversation = new List<string>();
    public List<string> thirdConversation = new List<string>();
    public GameObject dialogSystem;

    void Start()
    {
        npcName = "Frontliner 1";
        eventConvo = "firstConversation";
        firstConversationEnd = false;
        secondConversationEnd = false;
        endSceneStopper = false;
        sequencing = 0;
        StartCoroutine(ShowFirstNarration());
    }
    private void Update()
    {
        if (eventConvo.Equals("secondConversation") && firstConversationEnd == false)
        {
            StartCoroutine(ShowSecondConversation());
            firstConversationEnd = true;
        }
        else if (eventConvo.Equals("thirdConversation") && secondConversationEnd == false)
        {
            StartCoroutine(ShowThirdConversation());
            secondConversationEnd = true;
        }
        else if (eventConvo.Equals("endScene") && endSceneStopper == false)
        {
            StartCoroutine(EndScene());
            endSceneStopper = true;
        }
    }

    public IEnumerator ShowFirstNarration()
    {
        yield return new WaitForSeconds(3);
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, conversation);
        //TODO: After this conversation. guard should move on one direction before fading out and make the player move again
        //Target: to get inside the quarantine camp (one way only)
    }

    public IEnumerator ShowSecondConversation()
    {
        npcName = "Kael";
        yield return new WaitForSeconds(3);
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, secondConversation);
    }

    public IEnumerator ShowThirdConversation()
    {
        yield return new WaitForSeconds(3);
        npcName = "Veteran";
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, thirdConversation);
    }

    public IEnumerator EndScene()
    {
        yield return new WaitForSeconds(1);
        black.SetTrigger("FadeOut");
        //there should be a trigger of loadscene management in keyframe animation to change scene
    }
}
