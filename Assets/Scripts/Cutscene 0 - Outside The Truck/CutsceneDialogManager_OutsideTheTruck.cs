using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneDialogManager_OutsideTheTruck : MonoBehaviour
{
    public GameObject dialogPanel;
    public CutsceneDialogManager_OutsideTheTruck dialogManager;
    public Animator black;
    public Animator black2;

    // Animators for the NPCs and humans
    public Animator animator_Stand_Veteran;
    public Animator animator_Stand_Guard1;
    public Animator aniamtor_Stand_Frontliner1;
    public Animator animator_Stand_Kael;
    public Animator animator_Stand_Coco;
    public Animator animator_Stand_Maria;
    public Animator aniamtor_Stand_Guard2_1;
    public Animator aniamtor_Stand_Guard2_2;

    //

    public Text npcNameText;
    public Text dialogText;
    public Button endDialogueButton;
    public Button nextDialogueButton;
    private List<string> conversation;
    private int convoIndex;

    void Start()
    {
        convoIndex = 0;
        animator_Stand_Kael.SetBool("Start_Talk", true);
        animator_Stand_Coco.SetBool("Start_Talk", true);
        animator_Stand_Maria.SetBool("Start_Talk", true);
        aniamtor_Stand_Guard2_1.SetBool("Start_Talk", true);
        aniamtor_Stand_Guard2_2.SetBool("Start_Talk", true);
    }

    // Update is called once per frame
    void Update()
    {

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

    //Responsible for changing the names every change of line depending on the situation
    public void Next()
    {
        if (convoIndex < conversation.Count - 1)
        {
            if (convoIndex == 0)
            {
                npcNameText.text = "Veteran";

                animator_Stand_Guard1.SetBool("Start_Talk", false);

                animator_Stand_Veteran.SetTrigger("ShowID");

                animator_Stand_Veteran.SetBool("Start_ShowingID", true);

            }
            else if (convoIndex == 1)
            {
                npcNameText.text = "Guard";

                animator_Stand_Veteran.SetBool("Start_ShowingID", false);

                animator_Stand_Guard1.SetBool("Start_Talk", true);  // Change this to checking Anim
            }
            else if (convoIndex == 2)
            {
                npcNameText.text = "Veteran";

                animator_Stand_Guard1.SetBool("Start_Talk", false);

                animator_Stand_Veteran.SetBool("Start_Talk", true);
            }
            else if (convoIndex == 3)
            {
                npcNameText.text = "Frontliner Jessie";

                animator_Stand_Veteran.SetBool("Start_Talk", false);

                aniamtor_Stand_Frontliner1.SetBool("Start_Talk", true);
            }
            convoIndex += 1;
            ShowText();
        }
        else
        {
            dialogPanel.SetActive(false);

            //Use startcoroutine here
            //Start the animation of the frontliner exiting the scene
            //Next scene
            StartCoroutine(EndScene());


        }
    }

    IEnumerator EndScene()
    {
        aniamtor_Stand_Frontliner1.SetBool("Start_Talk", false);
        aniamtor_Stand_Frontliner1.SetBool("Start_Walk_Right", true);
        aniamtor_Stand_Frontliner1.SetTrigger("Trigger_Walk_Right");
        yield return new WaitForSeconds(2);
        black2.SetTrigger("FadeOut2");
    }
}
