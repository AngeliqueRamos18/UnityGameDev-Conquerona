using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneDialogManager_MessedUpTent : MonoBehaviour
{
    public GameObject dialogPanel;
    public CutsceneDialogManager_MessedUpTent dialogManager;
    public Animator black;
    public Animator black2;
    // Animators for cutscenes    
    public Animator maria;
    
    //
    public Text npcNameText;
    public Text dialogText;
    public Button endDialogueButton;
    public Button nextDialogueButton;
    private List<string> conversation;
    private int convoIndex;

    public GameObject bagIcon;
    public GameObject ctrlButtons;
    public PlayerMovement pcControl;
    public bool firstAct;
    void Start()
    {
        convoIndex = 0;
        pcControl.enabled = false;
        firstAct = false;
    }

    public void Start_Dialog(string _npcName, List<string> _convo)
    {
        bagIcon.SetActive(false);
        ctrlButtons.SetActive(false);
        pcControl.enabled = false;
        npcNameText.text = _npcName;
        conversation = new List<string>(_convo);
        dialogPanel.SetActive(true);
        convoIndex = 0;

        if (Cutscene_0_MessedUpTent_Script.eventConvo.Equals("firstPart") && firstAct == false)
        {
            maria.SetBool("Start_Concerned", true);
            firstAct = true;
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
            if (Cutscene_0_MessedUpTent_Script.eventConvo.Equals("firstPart"))
            {
                if(convoIndex == 0)
                {
                    maria.SetBool("Start_Concerned", false);
                    npcNameText.text = "Kael";
                }
                else if(convoIndex == 1)
                {
                    npcNameText.text = "Maria";
                    maria.SetBool("Start_Concerned", true);
                }
            }
            else if (Cutscene_0_MessedUpTent_Script.eventConvo.Equals("chatMaria"))
            {
                maria.SetBool("Start_Talk", true);
            }
           
            convoIndex += 1;
            ShowText();
        }
        else
        {
            if (Cutscene_0_MessedUpTent_Script.eventConvo.Equals("firstPart"))
            {
                //When the last line is done, the control buttons should activate (Canvas2)
                dialogPanel.SetActive(false);
                maria.SetBool("Start_Concerned", false);

                // In this part dapat maactivate yung player, expect na maraming error dahil maraming kulang
                //magbase sa components na meron sa Adventure mode, imemerge
                bagIcon.SetActive(true);
                ctrlButtons.SetActive(true);
                pcControl.enabled = true;
                Cutscene_0_MessedUpTent_Script.eventConvo = "chatMaria";
            }
            else if (Cutscene_0_MessedUpTent_Script.eventConvo.Equals("chatMaria"))
            {
                dialogPanel.SetActive(false);
                ctrlButtons.SetActive(true);
                bagIcon.SetActive(true);
                pcControl.enabled = true;
                maria.SetBool("Start_Talk", false);
            }
                
           
        }
    }

    public IEnumerator EndScene()
    {
        yield return new WaitForSeconds(0.1f);
        black2.SetTrigger("FadeOut2");
    }
}
