using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager_InsideTheTentVS : MonoBehaviour
{
    public GameObject dialogPanel;
    public DialogManager_InsideTheTentVS dialogManager;
    public Text dialogText;
    public Text npcNameText;
    public Button endDialogueButton;
    public Button nextDialogueButton;
    private List<string> conversation;
    private int convoIndex;
    public PlayerMovement playerMovementPC;

    public Animator blackControls;
    public GameObject ctrlButtons;

    void Start()
    {
       
        dialogPanel.SetActive(false);
        convoIndex = 0;
        playerMovementPC.enabled = true;   
    }

    public void Start_Dialog(string _npcName, List<string> _convo)
    {
        playerMovementPC.enabled = false;
        npcNameText.text = _npcName;
        conversation = new List<string>(_convo);
        dialogPanel.SetActive(true);
        convoIndex = 0;
        ctrlButtons.SetActive(false);
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
        if(convoIndex < conversation.Count - 1)
        {
            convoIndex += 1;
            ShowText();
        }
        else
        {
            
            dialogPanel.SetActive(false);
            ctrlButtons.SetActive(true);
            playerMovementPC.enabled = true;

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
