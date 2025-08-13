using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;


public class Cutscene_0_OutsideTheTruck_Script : MonoBehaviour
{
    public static int sequencing;
    public static string eventConvo;
    public static string npcName;
    public Animator black;
    // To start the animation of the first element
    public Animator animator_Stand_Gaurd1;
    //
    public CutsceneDialogManager_OutsideTheTruck dialogManager;
    public List<string> conversation = new List<string>();
    public GameObject dialogSystem;

    void Start()
    {
        npcName = "Guard";
        eventConvo = "firstConversation";
        sequencing = 0;
        StartCoroutine(ShowFirstNarration());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ShowFirstNarration()
    {
        yield return new WaitForSeconds(3);
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, conversation);
        animator_Stand_Gaurd1.SetBool("Start_Talk", true);
        //TODO: After this conversation. guard should move on one direction before fading out and make the player move again
        //Target: to get inside the quarantine camp (one way only)
    }
}
