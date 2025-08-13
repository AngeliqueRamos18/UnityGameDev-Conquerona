using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager_BattleMode_Tutorial : MonoBehaviour
{
    public GameObject dialogPanel;
    public Text dialogText;
    public GameObject BattleButtons;
    public GameObject Controller;
    public Button nextDialogueButton;
    private List<string> conversation;
    private int convoIndex;
    public static bool doneTalking;
    public static string eventConvo;
    public Text npcNameText;


    public Animator white;
    public Animator black;
    public Animator vet;

    void Start()
    {
        convoIndex = 0;
        BattleButtons.SetActive(false);
        Controller.SetActive(false);
        doneTalking = false;
        vet.SetBool("Start_Talk", false);
        vet.SetBool("Start_Talk", true);
    }

    private void Update()
    {
  
    }

    public void Start_Dialog(string _npcName, List<string> _convo)
    {
        npcNameText.text = _npcName;
        conversation = new List<string>(_convo);
        dialogPanel.SetActive(true);
        convoIndex = 0;
        ShowText();
        Controller.SetActive(false);
        BattleButtons.SetActive(false);
        Target_MainFunctions_Tutorial.pause = true; //Stops all the enemies from moving
        PlayerMovement.talking = true; //sets the talking to true kapag nag start na dialog
    }

    public void StopDialog()
    {
        Controller.SetActive(true);
        BattleButtons.SetActive(true);
        dialogPanel.SetActive(false);
        nextDialogueButton.interactable = true;
        PlayerMovement.talking = false;
    }

    private void ShowText()
    {
        dialogText.text = conversation[convoIndex];
    }

    public void Next()
    {
        if (convoIndex < conversation.Count - 1)
        {
            convoIndex += 1;
            ShowText();
        }
        else //If the conversation reaches the last line
        {
            if (BattleMode_Script.eventConvo.Equals("firstPart"))
            {
                dialogPanel.SetActive(false);
                Controller.SetActive(true);
                BattleButtons.SetActive(true);
                vet.SetBool("Start_Talk", false);
                PlayerMovement.talking = false;
                Target_MainFunctions_Tutorial.pause = false;
            }
            else if (BattleMode_Script.eventConvo.Equals("secondPart"))
            {
                dialogPanel.SetActive(false);
                Controller.SetActive(true);
                BattleButtons.SetActive(true);
                vet.SetBool("Start_Talk", false);
                PlayerMovement.talking = false;
                Target_MainFunctions_Tutorial.pause = false;
            }
            else if (BattleMode_Script.eventConvo.Equals("thirdPart"))
            {
                dialogPanel.SetActive(false);
                Controller.SetActive(true);
                BattleButtons.SetActive(true);
                vet.SetBool("Start_Talk", false);
                PlayerMovement.talking = false;
                Target_MainFunctions_Tutorial.pause = false;
                white.SetTrigger("FadeOut");
            }


        }
    }

    public void Hide()
    {
        Controller.SetActive(true);
        BattleButtons.SetActive(true);
        dialogPanel.SetActive(false);
        nextDialogueButton.interactable = true;
        PlayerMovement.talking = false;
        doneTalking = true;
    }
}
