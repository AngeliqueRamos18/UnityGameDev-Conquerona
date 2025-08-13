using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Cutscene_0_InsideTheTruck_Script : MonoBehaviour
{
    public static int sequencing;
    public static string eventConvo;
    public static string npcName;
    public Animator black;
    public Animator black2;
    public CutsceneDialogManager_InsideTheTruck dialogManager;
    public List<string> narrator = new List<string>();
    public List<string> allConversation = new List<string>();
    public GameObject dialogSystem;

    public void Start()
    {
        npcName = " ";
        eventConvo = "firstNarration";
        sequencing = 0;
        StartCoroutine(ShowFirstNarration());
        
        
    }

    private void Update()
    {
        //This prevents the Startcoroutines to start all at once and finish their sequences
        if(sequencing == 1)
        {
            StartCoroutine(DelayedFadeOut());
        }else if(sequencing == 2)
        {
            StartCoroutine(ShowConversation());
            //Prevents the dialogue from getting stucked in the first line <sequencing>
            sequencing = 0;
        }else if(sequencing == 3)
        {
            StartCoroutine(NextScene());
            sequencing = 0;
        }
    }

    public IEnumerator ShowFirstNarration()
    {
        yield return new WaitForSeconds(2);
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, narrator);
    }
    public IEnumerator ShowConversation()
    {

        eventConvo = "firstConversation";
        npcName = "Veteran";
        //start of the engine sound

        //appearance of the first scene
        yield return new WaitForSeconds(2);
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, allConversation);
    }

    public IEnumerator DelayedFadeOut()
    {
        yield return new WaitForSeconds(0.5f);
        black.SetTrigger("fadeOut");
        sequencing = 2;
    }

    public IEnumerator NextScene()
    {
        black2.SetTrigger("fadeOut2");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(3);   
    }

    //public void OnMouseDown() // starts dialog by clicking on object
    //{
    //    dialogManager.Start_Dialog(npcName, npcConvo);
    //}

}
