using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneDialogManager_InsideTheTruck : MonoBehaviour
{
    public GameObject dialogPanel;
    public CutsceneDialogManager_InsideTheTruck dialogManager;
    public Animator black;
    public Animator black2;
    public Animator microbePic;
    public Animator infected;
    public Animator betweenFade;

    // Animators for the NPCs and humans
    public Animator animator_Sit_Kael;
    public Animator animator_Sit_Coco;
    public Animator animator_Sit_Maria;
    public Animator animator_Stand_Veteran;

    //
    public Text npcNameText;
    public Text dialogText;
    public Button endDialogueButton;
    public Button nextDialogueButton;
    private List<string> conversation;
    private int convoIndex;
    public static bool doneTalking;
    void Start()
    {
        convoIndex = 0;
        doneTalking = false;
    }
    public void Start_Dialog(string _npcName, List<string> _convo)
    {
        npcNameText.text = _npcName;
        conversation = new List<string>(_convo);
        dialogPanel.SetActive(true);
        convoIndex = 0;
        ShowText();
    }

    public void StopDialog()
    {
        dialogPanel.SetActive(false);
        nextDialogueButton.interactable = true;
        endDialogueButton.interactable = false;
    }

    private void ShowText()
    {
        dialogText.text = conversation[convoIndex];
    }

    public void Next()
    {
        if (convoIndex < conversation.Count - 1)
        {
            //Scenes for popping up some pictures and fade out fade in of the black
            //Narration dialogue
            if (Cutscene_0_InsideTheTruck_Script.eventConvo.Equals("firstNarration"))
            {
                if (convoIndex == 0)
                {
                    black.SetTrigger("fadeOut");
                }

                if (convoIndex == 1)
                {
                    //black.SetTrigger("fadeIn");
                    microbePic.SetTrigger("microbeFadeOut");
                }

                if (convoIndex == 2)
                {
                    //black.SetTrigger("fadeOut");
                }

            //This is for the second dialogue box that will appear   
            //Small Suggestion would to turn this into a switch case when returning to the project after the expo
            }else if (Cutscene_0_InsideTheTruck_Script.eventConvo.Equals("firstConversation"))
            {
                if (convoIndex == 0)
                {
                    animator_Stand_Veteran.SetBool("Start_Talk", true);
                }
                else if (convoIndex == 2)
                {
                    //responsible for changing the gameobject's text
                    npcNameText.text = "Kael";
                    // Plays the Animation of the char
                    animator_Stand_Veteran.SetBool("Start_Talk", false);

                    animator_Sit_Kael.SetBool("Start_QuestionMark", true);
                    

                }else if(convoIndex == 3)
                {
                    npcNameText.text = "Veteran";

                    // End previous Anim
                    animator_Sit_Kael.SetBool("Start_QuestionMark", false);

                    // Start New Anim
                    animator_Stand_Veteran.SetBool("Start_Talk", true);
                }else if(convoIndex == 4)
                {
                    npcNameText.text = "Coco";

                    animator_Stand_Veteran.SetBool("Start_Talk", false);


                    animator_Sit_Coco.SetBool("Start_Annoyed", true);
                }else if(convoIndex == 5)
                {
                    npcNameText.text = "Veteran";

                    animator_Stand_Veteran.SetBool("Start_Annoyed", true);

                }else if(convoIndex == 6)
                {
                    npcNameText.text = "Kael";

                    animator_Stand_Veteran.SetBool("Start_Annoyed", false);
                    animator_Sit_Coco.SetBool("Start_Annoyed", false);

                    animator_Sit_Kael.SetBool("Start_Deny", true);
                }
                else if(convoIndex == 7)
                {
                    npcNameText.text = "Maria";

                    animator_Sit_Kael.SetBool("Start_Deny", false);

                    animator_Sit_Maria.SetBool("Start_Inform", true);
                }
                else if(convoIndex == 8)
                {
                    npcNameText.text = "Veteran";

                    animator_Sit_Maria.SetBool("Start_Inform", false);

                    animator_Stand_Veteran.SetBool("Start_Annoyed", true);

                }else if(convoIndex == 9)
                {
                    npcNameText.text = "Veteran";

                    animator_Stand_Veteran.SetBool("Start_Annoyed", false);

                    animator_Stand_Veteran.SetBool("Start_Talk", true);
                } 
            }

            convoIndex += 1;
            ShowText();
        }
        else
        {
            //if it reaches to the last line, it will trigger this event
            if (Cutscene_0_InsideTheTruck_Script.eventConvo.Equals("firstNarration"))
            {
                //The last pic of infected will clear out before proceeding to the next image sprites which was covered by the intro pics
                infected.SetTrigger("infectedFadeOut");
                black.SetTrigger("fadeIn");
                betweenFade.SetTrigger("startFade");
                dialogPanel.SetActive(false);
                Cutscene_0_InsideTheTruck_Script.sequencing = 1;

            }else if (Cutscene_0_InsideTheTruck_Script.eventConvo.Equals("firstConversation"))
            {
                dialogPanel.SetActive(false);
                black2.SetTrigger("fadeOut2");
                Cutscene_0_InsideTheTruck_Script.sequencing = 3;
            }
            


        }
    }

    public void Hide()
    {
        dialogPanel.SetActive(false);
        nextDialogueButton.interactable = true;
        endDialogueButton.interactable = false;
    }
}
