using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CutsceneDialogManager_InsideTheTent3 : MonoBehaviour
{
    public GameObject dialogPanel;
    public CutsceneDialogManager_InsideTheTent3 dialogManager;
    public Animator black;
    public Animator black2;
    public Text npcNameText;
    public Text dialogText;
    public Button endDialogueButton;
    public Button nextDialogueButton;
    private List<string> conversation;
    private int convoIndex;

    const string player_Idle = "Player_Idle";
    public static bool firstAct;
    public static bool secondAct;
    public Animator coco;
    public Animator vet;
    public Animator maria;
    public Animator kael;
    public Animator old;

    void Start()
    {
        convoIndex = 0;
        firstAct = false;
        secondAct = false;
    }

    public void Start_Dialog(string _npcName, List<string> _convo)
    {
        if(firstAct == false)
        {
            //Animation of coco going near to the volunteer
            vet.SetBool("Start_Talk", true);
            firstAct = true;
        }

        if(Cutscene_0_InsideTheTent3_Script.eventConvo.Equals("secondConversation") && secondAct == false)
        {
            StartCoroutine(ActionKael());
        }

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
            if (Cutscene_0_InsideTheTent3_Script.eventConvo.Equals("firstConversation"))
            {
                if (convoIndex == 0)
                {
                    vet.SetBool("Start_Talk", false);
                    StartCoroutine(ActionCoco());
                    npcNameText.text = "Coco";
                }
                else if (convoIndex == 1)
                {
                    vet.SetBool("Start_Talk", true);
                    npcNameText.text = "Veteran";
                    coco.SetBool("ITT3_GoNear", false);
                }
                else if (convoIndex == 2)
                {
                    vet.SetBool("Start_Talk", false);
                    coco.SetBool("Start_ShowSyringe", true);
                    npcNameText.text = "Coco";
                    //This holds coco's position
                    coco.applyRootMotion = true;
                    
                }
                else if (convoIndex == 3)
                {
                    /*coco.SetBool("Start_Inform", false);*/
                    npcNameText.text = "Maria";
                    maria.SetBool("Start_Annoy", true);
                }
            }
            else if (Cutscene_0_InsideTheTent3_Script.eventConvo.Equals("secondConversation"))
            {
                if (convoIndex == 0)
                {
                    old.SetBool("Cough", false);
                    coco.SetBool("Start_InfectCoco", false);
                    npcNameText.text = "Kael";
                    kael.applyRootMotion = true;
                    kael.SetBool("Start_Concern", true);
                }
                else if(convoIndex == 1)
                {
                    npcNameText.text = "Coco";
                    coco.SetBool("Start_Talk", true);
                }
                else if (convoIndex == 2)
                {
                    npcNameText.text = "Kael";
                }
                else if (convoIndex == 3)
                {
                    npcNameText.text = "Coco";
                    kael.SetBool("Start_Concern", false);
                }
            }
                convoIndex += 1;
            ShowText();
        }
        else
        { 
            //When it reaches the last line of a conversation
            if (Cutscene_0_InsideTheTent3_Script.eventConvo.Equals("firstConversation"))
            {
                dialogPanel.SetActive(false);
                maria.SetBool("Start_Annoy", false);
                //In this part the animation of old coughing starts here
                //After coughing coco should changes its sprite into infected
                StartCoroutine(InfectCoco());
                //////////////////
                Cutscene_0_InsideTheTent3_Script.eventConvo = "secondConversation";
            }
            else if (Cutscene_0_InsideTheTent3_Script.eventConvo.Equals("secondConversation"))
            {
                dialogPanel.SetActive(false);
                //Fade black should be exactly before Coco punches kael and punch sound effect should be played here
                //Tip: Para di mahirapan sa animation pwedeng kapag mananapaj na si coco, yung 
                //original sprite na si kael ihihide agad, and then sa animation ni coco andun si kael na sinuntok niya
                //para isahang timing lang at sakto at least

                coco.SetBool("Start_Punch", true);
                kael.SetBool("Start_Punch", true);


                //This is responsible for triggering the black transition after the punch
                //Adjust nalang yung timing ng WaitForSeconds pag hindi sakto sa timing ng suntok
                StartCoroutine(EndScene());
                
            }
        }
    }

    public IEnumerator EndScene()
    {
        yield return new WaitForSeconds(0.7f);
        black2.SetTrigger("FadeOut2");
    }

    public IEnumerator ActionCoco()
    {
        nextDialogueButton.interactable = false;
        coco.SetBool("Start_Talk", true);
        yield return new WaitForSeconds(0.5f);
        coco.SetBool("Start_Talk", false);
        coco.SetBool("ITT3_GoNear", true);
        yield return new WaitForSeconds(2);
        nextDialogueButton.interactable = true;
    }

    public IEnumerator InfectCoco()
    {
        old.SetBool("Cough", true);
        coco.SetBool("Start_InfectCoco", true);
        yield return new WaitForSeconds(0.5f);
        old.SetBool("Cough", false);
        old.SetBool("Start_Idle", true);
    }

    public IEnumerator ActionKael()
    {
        nextDialogueButton.interactable = false;
        kael.SetBool("ITT3_GoNear", true);
        secondAct = true;
        yield return new WaitForSeconds(2);
        nextDialogueButton.interactable = true;
    }
}
