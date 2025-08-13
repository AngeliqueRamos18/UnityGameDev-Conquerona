using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneDialogManager_QuarantineCamp : MonoBehaviour
{
    public GameObject dialogPanel;
    public CutsceneDialogManager_QuarantineCamp dialogManager;
    public Animator black;
    public Text npcNameText;
    public Text dialogText;
    public Button endDialogueButton;
    public Button nextDialogueButton;
    private List<string> conversation;
    private int convoIndex;

    void Start()
    {
        convoIndex = 0;
    }

    public void Start_Dialog(string _npcName, List<string> _convo)
    {
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
            if (Cutscene_0_QuarantineCamp_Script.eventConvo.Equals("firstConversation"))
            {
                if (convoIndex == 0)
                {
                    npcNameText.text = "Veteran";
                }
                else if (convoIndex == 1)
                {
                    npcNameText.text = "Robert";
                }
                else if (convoIndex == 2)
                {
                    npcNameText.text = "Veteran";
                }
                else if (convoIndex == 3)
                {
                    npcNameText.text = "Robert";
                }
            }
            else if (Cutscene_0_QuarantineCamp_Script.eventConvo.Equals("secondConversation"))
            {
            
                if (convoIndex == 0)
                {
                    npcNameText.text = "Coco";
                }
                else if (convoIndex == 1)
                {
                    npcNameText.text = "Maria";
                }
                else if (convoIndex == 2)
                {
                    npcNameText.text = "Coco";
                }
                else if (convoIndex == 3)
                {
                    npcNameText.text = "Frontliner 1";
                }
                
            }
                
            convoIndex += 1;
            ShowText();
        }
        else
        {
            //last line ng first conversation
            if (Cutscene_0_QuarantineCamp_Script.eventConvo.Equals("firstConversation"))
            {
                dialogPanel.SetActive(false);
                //dapat after this part may animation na iiba yung facing direction ng mga sprites dun kila Kael at Gang
                Cutscene_0_QuarantineCamp_Script.eventConvo = "secondConversation";
                
            }
            else if (Cutscene_0_QuarantineCamp_Script.eventConvo.Equals("secondConversation"))
            {
                //On this part ito yung last line na "When you're done chatting..."
                //May animation sila frontliner at rebert na wawalk away
                dialogPanel.SetActive(false);
                Cutscene_0_QuarantineCamp_Script.eventConvo = "thirdConversation";
            }
            else if (Cutscene_0_QuarantineCamp_Script.eventConvo.Equals("thirdConversation"))
            {
                black.SetTrigger("FadeOut");
;               dialogPanel.SetActive(false);
                Cutscene_0_QuarantineCamp_Script.eventConvo = "endScene";
                Debug.Log("convoindex: " + convoIndex);
                //Ito na yung last line na pahabol ni veteran
                //Animation fade out will occur to the next scene kung saan si player na
                //cocontrol
            }
        }
    }
}
