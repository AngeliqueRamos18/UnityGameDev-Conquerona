using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Cutscene_0_BossFightIntro_Script : MonoBehaviour
{
    public static int sequencing;
    public static string eventConvo;
    public static string npcName;
    public bool firstConversationEnd;
    public Animator red;
    public CutsceneDialogManager_BossFightIntro dialogManager;
    public List<string> conversation = new List<string>();
    public GameObject dialogSystem;

    void Start()
    {
        npcName = "Coco";
        eventConvo = "firstConversation";
        firstConversationEnd = false;
        sequencing = 0;
        StartCoroutine(ShowFirstNarration());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ShowFirstNarration()
    {
        yield return new WaitForSeconds(5.5f);
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, conversation);
    }
}
