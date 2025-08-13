using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneDialogManager_BossFightOutro : MonoBehaviour
{
    public GameObject dialogPanel;
    public CutsceneDialogManager_BossFightOutro dialogManager;
    public Animator black2;
    public Animator black;
    public Text npcNameText;
    public Text dialogText;
    public Button endDialogueButton;
    public Button nextDialogueButton;
    private List<string> conversation;
    private int convoIndex;

    public FlipSprite vetFlip;
    public FlipSprite cocoFlip;
    public FlipSprite kaelFlip;
    public Animator vet;
    public Animator coco;
    public Animator kael;
    public Animator frontliner1;
    public Animator frontliner2;
    public Animator camera;
    public Animator hallucination;
    public int faceRight;
    void Start()
    {        
        vetFlip = GameObject.Find("Stand_Veteran").GetComponent<FlipSprite>();
        cocoFlip = GameObject.Find("Coco").GetComponent<FlipSprite>();
        kaelFlip = GameObject.Find("Player").GetComponent<FlipSprite>();
        convoIndex = 0;
        //Veteran's direction: left
        vetFlip.Flip();
        //Coco's direction: right
        cocoFlip.Flip();

        
    }

    void Update()
    {
        
    }

    public void Start_Dialog(string _npcName, List<string> _convo)
    {
        
        npcNameText.text = _npcName;
        conversation = new List<string>(_convo);
        dialogPanel.SetActive(true);
        convoIndex = 0;

        if (Cutscene_0_BossFightOutro_Script.eventConvo.Equals("firstConversation"))
        {
            coco.SetBool("Talk", false);
            coco.SetBool("Annoyed", true);
        }

        if (Cutscene_0_BossFightOutro_Script.eventConvo.Equals("secondConversation"))
        {
            StartCoroutine(TalkVet());
        }

        if (Cutscene_0_BossFightOutro_Script.eventConvo.Equals("fourthConversation"))
        {
            StartCoroutine(Hallucinate());
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
            if (Cutscene_0_BossFightOutro_Script.eventConvo.Equals("firstConversation"))
            {
                if (convoIndex == 1)
                {
                    coco.SetBool("Annoyed", false);
                    coco.SetBool("Idle", true);
                    npcNameText.text = "Veteran";
                }
            }
            else if (Cutscene_0_BossFightOutro_Script.eventConvo.Equals("fifthConversation"))
            {
                if (convoIndex == 0)
                {
                    kael.SetBool("Up", false);
                    npcNameText.text = "Kael";
                }
                else if (convoIndex == 1)
                {
                    npcNameText.text = "Veteran";
                }
            }
            convoIndex += 1;
            ShowText();
        }
        else if (Cutscene_0_BossFightOutro_Script.eventConvo.Equals("secondConversation"))
        {

            dialogPanel.SetActive(false);
            StartCoroutine(CocoLeave());
            cocoFlip.Flip();
            Cutscene_0_BossFightOutro_Script.eventConvo = "thirdConversation";

        }
        else //If the dialogue reaches the last line
        {
            if (Cutscene_0_BossFightOutro_Script.eventConvo.Equals("firstConversation"))
            {
                dialogPanel.SetActive(false);
                camera.SetBool("camera1", true);
                StartCoroutine(EntryVet());
                Cutscene_0_BossFightOutro_Script.eventConvo = "secondConversation";

            }
            else if (Cutscene_0_BossFightOutro_Script.eventConvo.Equals("thirdConversation"))
            {
                //Animation of Veteran walking out should start here
                vet.applyRootMotion = false;
                vet.SetBool("Leave", true);
                camera.SetBool("camera2", true);
                dialogPanel.SetActive(false);
                Cutscene_0_BossFightOutro_Script.eventConvo = "fourthConversation";
            }
            else if (Cutscene_0_BossFightOutro_Script.eventConvo.Equals("fourthConversation"))
            {
                //Animation of Kael getting closer starts here
                hallucination.SetBool("Disappear", true);
                dialogPanel.SetActive(false);
                Cutscene_0_BossFightOutro_Script.eventConvo = "fifthConversation";

            }
            else if (Cutscene_0_BossFightOutro_Script.eventConvo.Equals("fifthConversation"))
            {
                dialogPanel.SetActive(false);
                //Kael will walk out then slowly fade out the screen
                kael.SetBool("End", true);
                camera.SetBool("camera3", true);
                black2.SetTrigger("FadeOut2");
                
                //Transition to the credits by fade out 
            }
        }
    }

    IEnumerator EntryVet()
    {
        yield return new WaitForSeconds(0.5f);
        vet.SetBool("Entry", true);
        frontliner1.SetBool("Entry", true);
        frontliner2.SetBool("Entry", true);
    }

    IEnumerator TalkVet()
    {
        vet.applyRootMotion = true;
        frontliner1.applyRootMotion = true;
        frontliner2.applyRootMotion = true;
        yield return new WaitForSeconds(1);
        vet.SetBool("Entry", false);
        frontliner1.SetBool("Entry", false);
        frontliner2.SetBool("Entry", false);
    }

    IEnumerator CocoLeave()
    {

        coco.SetBool("Coco_Go", true);
        yield return new WaitForSeconds(2.1f);
        //Animation of frontliners leaving start here
        frontliner1.SetBool("Leave", true);
        frontliner2.SetBool("Leave", true);
        yield return new WaitForSeconds(1);
        vetFlip.Flip();
        kaelFlip.Flip();
        vet.SetBool("Vet_GoNear", true);
        yield return new WaitForSeconds(2);
        vet.SetBool("Vet_GoNear", false);
        vet.SetBool("Talk", true);
        yield return new WaitForSeconds(0.5f);
        vetFlip.Flip();    
        
    }

    IEnumerator Hallucinate()
    {
        hallucination.SetBool("Appear", true);
        yield return new WaitForSeconds(0.5f);
        kael.SetBool("Up", true);
        yield return new WaitForSeconds(1.2f);
        hallucination.SetBool("Idle", true);
    }
}

