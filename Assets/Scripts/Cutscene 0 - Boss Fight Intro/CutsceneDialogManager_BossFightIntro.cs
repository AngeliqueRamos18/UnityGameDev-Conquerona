using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneDialogManager_BossFightIntro : MonoBehaviour
{
    public GameObject dialogPanel;
    public CutsceneDialogManager_BossFightIntro dialogManager;
    public Animator red;
    public Animator black;
    public Text npcNameText;
    public Text dialogText;
    public Button endDialogueButton;
    public Button nextDialogueButton;
    private List<string> conversation;
    private int convoIndex;

    public Animator camera;
    public Animator kael;
    public Animator coco;

    void Start()
    {
        convoIndex = 0;
        StartCoroutine(EntryKael());
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
        if(convoIndex < conversation.Count - 1)
        {
            if(convoIndex == 0)
            {
                coco.SetBool("Anger", true);
            }
            convoIndex += 1;
            ShowText();
        }
        else
        {
            dialogPanel.SetActive(false);
            red.SetTrigger("FadeIn");
            //Reminder dapat after ng fade nito ipapalit na ang scene na nagsisimula yung red fadeout naman
        }
    }

    public IEnumerator EntryKael()
    {
        yield return new WaitForSeconds(2.0f);
        kael.applyRootMotion = true;
        kael.SetBool("Player_Idle", true);
        StartCoroutine(CameraAnim());

    }
    

    public IEnumerator CameraAnim()
    {
        yield return new WaitForSeconds(1);
        camera.SetBool("FocusOnCoco", true);
    }
}
