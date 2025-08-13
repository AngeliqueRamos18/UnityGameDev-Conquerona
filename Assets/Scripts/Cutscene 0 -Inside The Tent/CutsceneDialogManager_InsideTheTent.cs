using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CutsceneDialogManager_InsideTheTent : MonoBehaviour
{
    public GameObject dialogPanel;
    public GameObject dialogPanel2;
    public CutsceneDialogManager_InsideTheTent dialogManager;
    public Animator black;
    public Text npcNameText;
    public Text npcNameText2;
    public Text dialogText;
    public Text dialogText2;
    public Button endDialogueButton;
    public Button nextDialogueButton;
    public Button nextDialogueButton2;
    private List<string> conversation;
    private int convoIndex;

    //New code: 05/21/21
    public Animator vet;
    public Animator sister;
    public Animator kael;
    public Animator robert;
    public Animator coco;
    public Animator maria;
    //On the first act it will activate the first actions of the specific npc 
    public bool firstAct;
    public bool secondAct;
    public GameObject ctrlButtons;
    public GameObject btnBag;
   
    void Start()
    {
        /*firstAct = false;
        secondAct = false;*/
        
        ctrlButtons.SetActive(false);
        btnBag.SetActive(false);
        convoIndex = 0;
        StartCoroutine(Anims());
    }

    private void Update()
    {
   
    }

    public void Start_Dialog(string _npcName, List<string> _convo)
    {
        PlayerMovement.talking = true;
        npcNameText.text = _npcName;
        conversation = new List<string>(_convo);
        dialogPanel.SetActive(true);
        convoIndex = 0;
        ctrlButtons.SetActive(false);

        if (Cutscene_0_InsideTheTent_Script.eventConvo.Equals("chatVeteran"))
        {
            vet.SetBool("Start_Talk", true);
        }

        ShowText();

        

    }
    //For the bag tutorial
    public void Start_Dialog2(string _npcName, List<string> _convo)
    {
        PlayerMovement.talking = true;
        npcNameText2.text = _npcName;
        conversation = new List<string>(_convo);
        dialogPanel2.SetActive(true);
        convoIndex = 0;
        ShowText2();

    }

    private void ShowText()
    {
        dialogText.text = conversation[convoIndex];
        
    }

    //For the bag tutorial text dialogue
    private void ShowText2()
    {
        dialogText2.text = conversation[convoIndex];

    }

    public void StopDialog()
    {
        dialogPanel.SetActive(false);
        nextDialogueButton.interactable = true;
        endDialogueButton.interactable = false;
    }

    public void Hide()
    {
        dialogPanel.SetActive(false);
        nextDialogueButton.interactable = true;
        endDialogueButton.interactable = false;
    }

    public void Next()
    {
        Debug.Log(convoIndex);
        if (convoIndex < conversation.Count - 1)
        {
            PlayerMovement.talking = true;
            if (convoIndex == 0)
            {
                npcNameText.text = "Robert";
                sister.SetBool("Talk", false);
                firstAct = true;
                
            }
            else if(convoIndex == 1)
            {
                npcNameText.text = "Veteran";
                sister.SetBool("Idle", true);
                vet.SetBool("Start_Talk", true);
                robert.SetBool("Start_Beg", false);
                robert.SetBool("Return_Idle", false);

            }
            else if(convoIndex == 2)
            {
                vet.SetBool("Start_Talk", false);

            }
            else if(convoIndex == 3)
            {
                npcNameText.text = "Coco & Maria";
                maria.SetBool("Start_Talk", true);
                coco.SetBool("Start_Talk", true);
            }
          
            convoIndex += 1;
            ShowText();
        }
        else if (Cutscene_0_InsideTheTent_Script.eventConvo.Equals("chatVeteran"))
        {
            dialogPanel.SetActive(false);
            vet.SetBool("Start_Talk", false);
            ctrlButtons.SetActive(true);
            PlayerMovement.talking = false;
        }
        else
        {
            maria.SetBool("Start_Talk", false);
            coco.SetBool("Start_Talk", false);
            dialogPanel.SetActive(false);
            //Control buttons should activate here
            
            btnBag.SetActive(true);
            Cutscene_0_InsideTheTent_Script.cutsceneDone = true;
            PlayerMovement.talking = true;

            //Sets the first part of ITT Quest to completed
            PlayerPrefs.SetInt("itt_Quest", 1);
        }
    }

    //For the next button bag tutorial dialogue
    public void Next2()
    {
        if(convoIndex < conversation.Count - 1)
        {
            convoIndex += 1;
            ShowText2();
        }
        else
        {
            vet.SetBool("Start_Talk", false);
            dialogPanel2.SetActive(false);
            ctrlButtons.SetActive(true);
            PlayerMovement.talking = false;
        }
    }

    public IEnumerator Anims()
    {
        PlayerMovement.talking = true;
        kael.SetBool("ITT_Entry", true);
        yield return new WaitForSeconds(2);
        kael.SetBool("ITT_Entry", false);

        //Purpose nitong root motion is that para after yung last position ng player, kapag nag play ng another
        //animation, hindi babalik sa original pwesto
        kael.applyRootMotion = true;
        sister.SetBool("Talk", true);
        //I used lambda expression here, instead of creating another function
        yield return new WaitUntil(() => firstAct == true);
        sister.SetBool("Talk", false);
        robert.SetBool("Return_Idle", false);
        robert.SetBool("Start_Beg", true);
    }
}
