using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneDialogManager_MessedUpQuarantineFacility : MonoBehaviour
{
    
    public SceneDialogManager_MessedUpQuarantineFacility dialogManager;
    public Animator black;
    public Animator black2;
    public Text npcNameText;
    public Text dialogText;
    public Button endDialogueButton;
    public Button nextDialogueButton;
    private List<string> conversation;
    private int convoIndex;
    public GameObject dialogPanel;

    public GameObject bagIcon;
    public GameObject ctrlButtons;
    public PlayerMovement pcControl;
    public bool firstAct;


    void Start()
    {
        convoIndex = 0;
        pcControl.enabled = true;
        ctrlButtons.SetActive(true);
        bagIcon.SetActive(true);
        firstAct = false;
    }

    public void Start_Dialog(string _npcName, List<string> _convo)
    {
        ctrlButtons.SetActive(false);
        pcControl.enabled = false;
        bagIcon.SetActive(false);
        npcNameText.text = _npcName;
        conversation = new List<string>(_convo);
        dialogPanel.SetActive(true);
        convoIndex = 0;
        ShowText();
    }

    private void ShowText()
    {
        dialogText.text = conversation[convoIndex];
    }
    public void StopDialog()
    {
        dialogPanel.SetActive(true);
        bagIcon.SetActive(true);
        ctrlButtons.SetActive(true);
        pcControl.enabled = true;
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
            if (Scene_0_MessedUpQuarantineFacility_Script.eventConvo.Equals("firstPart"))
            {
                dialogPanel.SetActive(false);
                bagIcon.SetActive(true);
                ctrlButtons.SetActive(true);
                pcControl.enabled = true;
                
            }
            else if (Scene_0_MessedUpQuarantineFacility_Script.eventConvo.Equals("chatVet"))
            {
                dialogPanel.SetActive(false);
                bagIcon.SetActive(true);
                ctrlButtons.SetActive(true);
                pcControl.enabled = true;
            }

            PlayerPrefs.SetInt("itt_Quest3", 1);
        }
    }

    public IEnumerator EndScene()
    {
        yield return new WaitForSeconds(0.1f);
        black2.SetTrigger("FadeOut2");
    }
}
