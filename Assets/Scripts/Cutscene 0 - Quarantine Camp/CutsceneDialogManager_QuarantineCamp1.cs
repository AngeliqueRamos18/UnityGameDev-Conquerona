using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneDialogManager_QuarantineCamp1 : MonoBehaviour
{
    public GameObject dialogPanel;
    public CutsceneDialogManager_QuarantineCamp1 dialogManager;
    public Animator black;
    public Text npcNameText;
    public Text dialogText;

    // Animators for the NPCs and humans
    public Animator animator_Stand_Kael;
    public Animator animator_Stand_Coco;
    public Animator animator_Stand_Maria;
    public Animator animator_Stand_Veteran;
    public Animator animator_Stand_Frontliner1;
    public Animator animator_Stand_Robert;

    public GameObject gameObject_Frontliner1;
    public SpriteRenderer sr_Frontliner1;
    ///

    public Button exitDialogueButton;
    public Button endDialogueButton;
    public Button nextDialogueButton;
    private List<string> conversation;
    private int convoIndex;
    public static bool ctrlButtons;
    public GameObject playerControl;
    // ======= Access Player movement Script======
    public PlayerMovement playerMovementPC;
    // ===========================================
    public static bool doneTalking;

    //For Movement Tutorial
    public GameObject dialogPanel2;
    public Text npcNameText2;
    public Text dialogText2;
    public Button nextDialogueButton2;


    void Start()
    {
        sr_Frontliner1 = gameObject_Frontliner1.GetComponent<SpriteRenderer>();
        convoIndex = 0;

        //responsible for the function of showing/hiding the player contrrols
        ctrlButtons = true;
        doneTalking = false;
        playerMovementPC.enabled = true;

    }

    private void Update()
    {
        if(Cutscene_0_QuarantineCamp_Script1.eventConvo.Equals("firstConversation") || Cutscene_0_QuarantineCamp_Script1.eventConvo.Equals("secondConversation") || Cutscene_0_QuarantineCamp_Script1.eventConvo.Equals("thirdConversation")){
            exitDialogueButton.interactable = false;
        }else{
            exitDialogueButton.interactable = true;
        }

        if (ctrlButtons == true)
        {
            playerControl.SetActive(true);
            playerMovementPC.enabled = true;
        }
        else
        {
            playerControl.SetActive(false);
            playerMovementPC.enabled = false;
            animator_Stand_Kael.SetFloat("Speed", 0.0f);
        }
    }

    public void Start_Dialog(string _npcName, List<string> _convo)
    {
       
        npcNameText.text = _npcName;
        conversation = new List<string>(_convo);
        dialogPanel.SetActive(true);
        convoIndex = 0;
        ShowText();
        ctrlButtons = false;
        //this prevents the player frrom moving
        PlayerMovement.talking = true; //sets the talking to true kapag nag start na dialog
        

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
        PlayerMovement.talking = false;
        doneTalking = true;
        ctrlButtons = true;
    }

    public void Hide()
    {
        dialogPanel.SetActive(false);
        nextDialogueButton.interactable = true;
        endDialogueButton.interactable = false;
        PlayerMovement.talking = false;
        doneTalking = true;
    }

    public void Next()
    {
         
        //kapag less than pa ito sa count ng string list 
        if (convoIndex < conversation.Count - 1)
        {
            if (Cutscene_0_QuarantineCamp_Script1.eventConvo.Equals("firstConversation"))
            {
                exitDialogueButton.interactable = false;

                if (convoIndex == 0)
                {
                    npcNameText.text = "Veteran";
             
                    animator_Stand_Frontliner1.SetBool("Start_Talk", false);
                    animator_Stand_Veteran.SetBool("Start_Talk", true);
                }
                else if (convoIndex == 1)
                {
                    npcNameText.text = "Robert";

                    animator_Stand_Veteran.SetBool("Start_Talk", false);
                    animator_Stand_Robert.SetBool("Start_Talk",true);
                }
                else if (convoIndex == 2)
                {
                    npcNameText.text = "Veteran";
                    
                    animator_Stand_Robert.SetBool("Start_Talk",false);
                    animator_Stand_Veteran.SetBool("Start_Think",true);
                }
                else if (convoIndex == 3)
                {
                    npcNameText.text = "Robert";
                    animator_Stand_Robert.SetBool("Start_Beg",true);
                    animator_Stand_Frontliner1.SetBool("Start_Talk",true);
                    animator_Stand_Kael.applyRootMotion = false;
                    
                }
            }
            else if (Cutscene_0_QuarantineCamp_Script1.eventConvo.Equals("secondConversation"))
            {
                exitDialogueButton.interactable = false;

                if (convoIndex == 0)
                {
                    npcNameText.text = "Coco";
                    animator_Stand_Veteran.SetBool("Start_Think", false);
                    animator_Stand_Frontliner1.SetBool("Start_Talk", false);
                    animator_Stand_Kael.SetBool("Start_Think", false);
                    animator_Stand_Coco.SetBool("Start_Annoy", true);
                }
                else if (convoIndex == 1)
                {
                    npcNameText.text = "Maria";
                    animator_Stand_Coco.SetBool("Start_Annoy", false);
                    animator_Stand_Maria.SetBool("Start_Talk", true);
                }
                else if (convoIndex == 2)
                {
                    npcNameText.text = "Coco";
                    animator_Stand_Maria.SetBool("Start_Talk", false);
                    animator_Stand_Coco.SetBool("Start_Inform", true);
                }
                else if (convoIndex == 3)
                {
                    npcNameText.text = "Frontliner Jessie";
                    sr_Frontliner1.flipX = true;
                    animator_Stand_Robert.SetBool("Start_Beg", false);
                    animator_Stand_Coco.SetBool("Start_Inform", false);
                    animator_Stand_Frontliner1.SetTrigger("Trigger_MoveUp_QC");
                }

            }

            convoIndex += 1;
            ShowText();
        } //kapag umabot na sa last line ng string list
        else
        {
            //last line ng first conversation
            if (Cutscene_0_QuarantineCamp_Script1.eventConvo.Equals("firstConversation"))
            {
                exitDialogueButton.interactable = false;
                dialogPanel.SetActive(false);
                animator_Stand_Kael.SetBool("QC_MoveUp", true);
                //dapat after this part may animation na iiba yung facing direction ng mga sprites dun kila Kael at Gang
                Cutscene_0_QuarantineCamp_Script1.eventConvo = "secondConversation";

            }
            else if (Cutscene_0_QuarantineCamp_Script1.eventConvo.Equals("secondConversation"))
            {
                exitDialogueButton.interactable = false;
                //On this part ito yung last line na "When you're done chatting..."
                //May animation sila frontliner at rebert na wawalk away
                sr_Frontliner1.flipX = false;
                animator_Stand_Frontliner1.SetTrigger("Trigger_MoveRight_QC");
                animator_Stand_Robert.SetTrigger("Trigger_MoveRight_QC");
                dialogPanel.SetActive(false);
                Cutscene_0_QuarantineCamp_Script1.eventConvo = "thirdConversation";
            }
            
            else if (Cutscene_0_QuarantineCamp_Script1.eventConvo.Equals("thirdConversation"))
            {
                exitDialogueButton.interactable = false;
               
                Cutscene_0_QuarantineCamp_Script1.eventConvo = "endScene";
            
                dialogPanel.SetActive(false);
                Debug.Log("convoindex: " + convoIndex);
             
                PlayerMovement.talking = false;
                
                ctrlButtons = false;

                //Sets the Quarantine Camp Quest to be completed
                PlayerPrefs.SetInt("quarantineCamp_Quest", 1);
                PlayerPrefs.SetInt("firstTimeQuarantineCamp", 1);
                PlayerPrefs.SetInt("talkJessie", 1);
            }
            else
            {
                ctrlButtons = true;
                dialogPanel.SetActive(false);
                //kapag hindi gumagalaw kasi nadedetect siya as talking parin 
                PlayerMovement.talking = false;
            }

        }
    }

    //Functions for the tutorial movement

    public void Start_Dialog2(string _npcName, List<string> _convo)
    {
        PlayerMovement.talking = true;
        playerMovementPC.enabled = false;
        npcNameText2.text = _npcName;
        conversation = new List<string>(_convo);
        dialogPanel2.SetActive(true);
        convoIndex = 0;
        ctrlButtons = false;
        ShowText2();

    }

    private void ShowText2()
    {
        dialogText2.text = conversation[convoIndex];
    }

    public void Next2()
    {
        if (convoIndex < conversation.Count - 1)
        {
            convoIndex += 1;
            ShowText2();
        }
        else
        {
            dialogPanel2.SetActive(false);
            ctrlButtons = true;
            PlayerMovement.talking = false;
        }
    }


    private void OnTriggerExit2D(Collider2D player)
    {
        doneTalking = false;
    }
}
