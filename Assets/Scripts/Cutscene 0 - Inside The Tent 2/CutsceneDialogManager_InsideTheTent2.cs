using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneDialogManager_InsideTheTent2 : MonoBehaviour
{
    public GameObject dialogPanel;
    public CutsceneDialogManager_InsideTheTent2 dialogManager;
    public Animator black;
    public Animator white;
    public Text npcNameText;
    public Text dialogText;
    public Button endDialogueButton;
    public Button nextDialogueButton;
    private List<string> conversation;
    private int convoIndex;

    //05/23/21

    public Animator vet;
    public Animator coco;
    public Animator maria;
    public Animator sis;
    public bool firstAct;
    public bool secondAct;
    public GameObject ctrlButtons;

    void Start()
    {
        convoIndex = 0;
        firstAct = false;
  
    }

    public void Start_Dialog(string _npcName, List<string> _convo)
    {
        npcNameText.text = _npcName;
        conversation = new List<string>(_convo);
        dialogPanel.SetActive(true);
        convoIndex = 0;
        ctrlButtons.SetActive(false);

        

        if (firstAct == false && Cutscene_0_InsideTheTent2_Script.talkVeteran == true)
        {
            vet.SetBool("Start_Talk", true);
            //prevents this function from repeating
            firstAct = true;

        }
        else if (secondAct == false && Cutscene_0_InsideTheTent2_Script.talkSis == true)
        {
            sis.SetBool("Talk", true);
            secondAct = true;
        }

        if (Cutscene_0_InsideTheTent2_Script.eventConvo.Equals("chatVeteran"))
        {
            vet.SetBool("Talk", true);
        }

        ShowText();
    }

    private void ShowText()
    {
        dialogText.text = conversation[convoIndex];
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
        if (convoIndex < conversation.Count - 1)
        {
            if (Cutscene_0_InsideTheTent2_Script.eventConvo.Equals("firstConversation"))
            {
                if(convoIndex == 0)
                {
                    vet.SetBool("Start_Talk", false);
                    coco.SetBool("Start_Talk", true);
                    npcNameText.text = "Coco";
                }
                else if(convoIndex == 1)
                {
                    coco.SetBool("Start_Talk", false);
                    npcNameText.text = "Maria";
                    maria.SetBool("Start_Talk", true);
                }
            }

            convoIndex += 1;
            ShowText();
        }
        else
        {
            //Kapag nakarating na sa last line ng first part na convo
            if (Cutscene_0_InsideTheTent2_Script.eventConvo.Equals("firstConversation"))
            {
                maria.SetBool("Start_Talk", false);
                dialogPanel.SetActive(false);
                Cutscene_0_InsideTheTent2_Script.eventConvo = "secondConversation";

                ctrlButtons.SetActive(true);
            }
            else if (Cutscene_0_InsideTheTent2_Script.eventConvo.Equals("secondConversation"))
            {
                
                dialogPanel.SetActive(false);
                sis.SetBool("Talk", false);
                white.SetTrigger("FadeOutWhite");

            }else if (Cutscene_0_InsideTheTent2_Script.eventConvo.Equals("chatSickSis"))
            {
                dialogPanel.SetActive(false);
                sis.SetBool("Talk", false);
                ctrlButtons.SetActive(true);
            }
            else if (Cutscene_0_InsideTheTent2_Script.eventConvo.Equals("chatVeteran"))
            {
                dialogPanel.SetActive(false);
                vet.SetBool("Talk", false);
                ctrlButtons.SetActive(true);
            }

            PlayerMovement.talking = false;
        }
    }
}
