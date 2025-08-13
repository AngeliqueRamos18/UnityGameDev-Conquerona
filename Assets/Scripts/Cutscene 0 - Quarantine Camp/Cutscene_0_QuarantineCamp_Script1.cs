using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Cutscene_0_QuarantineCamp_Script1 : MonoBehaviour
{
    public static int sequencing;
    public static string eventConvo;
    public static string npcName;
    public bool firstConversationEnd;
    public bool secondConversationEnd;
    public bool endSceneStopper;
    public Animator black;

    //Animators for Cutscene
    public Animator animator_Stand_Robert;
    public Animator animator_Stand_Kael;
    public Animator animator_Stand_Veteran;
    public Animator animator_Stand_Frontliner1;
    public SpriteRenderer sR_Kael;

    public GameObject stand_Robert;

    public bool robert_FacingRight;

    public GameObject go_Vet;
    public GameObject go_C;
    public GameObject go_M;
    //
    public CutsceneDialogManager_QuarantineCamp1 dialogManager;
    public List<string> conversation = new List<string>();
    public List<string> secondConversation = new List<string>();
    public List<string> thirdConversation = new List<string>();
    

    //Dialogue for the frontliner 2
    public List<string> dialogue_Frontlinter2 = new List<string>();

    //Dialogue for Frontliner Jessie
    public List<string> dialogue_Jessie = new List<string>();
    public GameObject dialogSystem;
    public bool talkFrontliner;

    public bool QuarantineCamp_Quest;


    //For the event trigger by talking
    public Button btnTalk;
    public bool startTalk;
    public PlayerMovement playerMovement;
    public static string collidedNPC;
    public GameObject walking;
    public int firstTime;

    public GameObject maria;
    public GameObject vet;
    public GameObject coco;
    public GameObject robert;
    public GameObject front;

    //Part for when the player has activated the Inventory feature
    public GameObject bagIcon;
    public int itt_Quest;
    public Item item;
    public bool hasShots;
    public bool vaccineShots;
    public bool talkJessie;

    //For movement tutorial
    public List<string> movementTutorial = new List<string>();


    void Start()
    {

        //Activates the bag icon feature
        if (PlayerPrefs.HasKey("itt_Quest"))
        {
            Debug.Log("Has key: itt_Quest");
            //Checks if the player has visited the tent 
            itt_Quest = PlayerPrefs.GetInt("itt_Quest");

        }

        //Checks if the player visited the quarantine camp for the first time to activate the tutorial
        if (PlayerPrefs.GetInt("firstTimeMovementTutorial") == 0)
        {
            CutsceneDialogManager_QuarantineCamp1.ctrlButtons = false;
            StartCoroutine(StartMovementTutorial());
            PlayerPrefs.SetInt("firstTimeMovementTutorial", 1);
        }

        firstTime = PlayerPrefs.GetInt("firstTimeQuarantineCamp"); // this automatically turns to

        bagIcon.SetActive(false);

        if (firstTime == 0)
        {
            sR_Kael = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
            FlipSprite flipSprite = stand_Robert.GetComponent<FlipSprite>();
        }
        //Checks if the player has talked to jessie even if he came in the tents before talking to them
        //So characters will not be destroyed right away
        else if (firstTime == 1 && PlayerPrefs.GetInt("talkJessie") == 1)
        {
            //Hides all of the npc when the player goes back to the quarantine from the tent
            maria.SetActive(false);
            vet.SetActive(false);
            coco.SetActive(false);
            robert.SetActive(false);
            front.SetActive(false);
        }

       

        //Checks if the player has the vaccine shots already
        if (PlayerPrefs.HasKey("Inventory"))
        {
            vaccineShots = PlayerPrefs.GetString("Inventory").Contains("VaccineShots");
        }

        startTalk = false;
        npcName = "Coco";
        collidedNPC = "";
        hasShots = false;

        
            
        
//masisira unless kung hindi na ito muna sinimulan, magbabase sa collision nalang din
        eventConvo = "";
        firstConversationEnd = false;
        secondConversationEnd = false;
        endSceneStopper = false;
        sequencing = 0;

        //Responsible whether if the player has talked to the fronlinter (set it as false, true for debugging)
        talkFrontliner = false;
        //Responsible of whether the player has talked to frontliner
        QuarantineCamp_Quest = false;

    }
    private void Update()
    {
        if(itt_Quest == 1)
        {
            bagIcon.SetActive(true);
        }

        //Checks if player got the vaccine then adds it in the inventory
        if (vaccineShots == true && hasShots == false)
        {
            Inventory.instance.Add(item);
            hasShots = true;
        }

        //Player should talk to the frontliner to activate the first dialogue
        if (talkFrontliner == true)
        {
            //Sets the button to hide
            CutsceneDialogManager_QuarantineCamp1.ctrlButtons = false;
            npcName = "Frontliner Jessie";
            StartCoroutine(ShowFirstNarration());
            talkFrontliner = false;
            
            animator_Stand_Robert.SetTrigger("Trigger_Walk_Left");
        }

        if (eventConvo.Equals("secondConversation") && firstConversationEnd == false)
        {
            StartCoroutine(ShowSecondConversation());
            firstConversationEnd = true;
        }
        else if (eventConvo.Equals("thirdConversation") && secondConversationEnd == false)
        {
            StartCoroutine(ShowThirdConversation());
            secondConversationEnd = true;
        }
        else if (eventConvo.Equals("endScene") && endSceneStopper == false)
        {
            StartCoroutine(EndScene());
            endSceneStopper = true;
        }

    }

    public IEnumerator StartMovementTutorial()
    {
        npcName = "Coco";
        yield return new WaitForSeconds(1);
        dialogManager.Start_Dialog2(npcName, movementTutorial);
        PlayerPrefs.SetInt("firstTimeMovementTutorial", 1);
    }
    public IEnumerator ShowFirstNarration()
    {
        yield return new WaitForSeconds(3);
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, conversation);
        animator_Stand_Robert.SetBool("Start_Walk_Left", false);
        animator_Stand_Frontliner1.SetBool("Start_Talk", true);
        //Target: to get inside the quarantine camp (one way only)
    }

    public IEnumerator ShowSecondConversation()
    {
        npcName = "Kael";
        animator_Stand_Kael.SetBool("QC_MoveUp", true);
        yield return new WaitForSeconds(2);
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, secondConversation);
        animator_Stand_Kael.SetBool("QC_MoveUp", false);
        animator_Stand_Kael.applyRootMotion = true;
        animator_Stand_Kael.SetBool("Start_Think", true);

    }

    public IEnumerator ShowThirdConversation()
    {
        animator_Stand_Veteran.SetTrigger("Trigger_MoveUp_QC");
        yield return new WaitForSeconds(2);
        npcName = "Veteran";
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, thirdConversation);

    }


    //On this part is the merged version of NPC script
    public void StartTalk()
    {
       if(btnTalk.interactable == true)
        {
            btnTalk.interactable = false;
            if (collidedNPC.Equals("NPC_Frontliner1") && QuarantineCamp_Quest == false)
            {
                //Sets the talkfrontliner to true which means it will activate the cutscene dialog
                talkFrontliner = true;
                QuarantineCamp_Quest = true;
            }
            else if(collidedNPC.Equals("NPC_Frontliner2")){
                //first parameter - name of npc, 2nd parameter - string list
                dialogManager.Start_Dialog(npcName, dialogue_Frontlinter2);
            }
            else if (collidedNPC.Equals("NPC_Jessie"))
            {
                dialogManager.Start_Dialog(npcName, dialogue_Jessie);
            }
        }
    }


//This will detect the collission between the player and any npc
    private void OnCollisionEnter2D(Collision2D collide)
    {
        //para hindi maulit ulit yung sinasabi ng frontliner 1 na cutscene
        if(collide.gameObject.CompareTag("NPC_Frontliner1") && QuarantineCamp_Quest == false)
        {
            eventConvo = "firstConversation";
            //reveals the talk button
            btnTalk.interactable = true;
            npcName = "Frontliner 1";
            collidedNPC = "NPC_Frontliner1";
        }
        else if (collide.gameObject.CompareTag("NPC_Frontliner2")){
            eventConvo = "chat_Frontliner2";
            btnTalk.interactable = true;
            npcName = "Frontliner 2"; //this displays the name in dialogue
            collidedNPC = "NPC_Frontliner2"; //checks the string value of the collided npc
        }
        else if (collide.gameObject.CompareTag("NPC_Jessie"))
        {
            eventConvo = "chat_Jessie";
            btnTalk.interactable = true;
            npcName = "Frontliner Jessie";
            collidedNPC = "NPC_Jessie";
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        btnTalk.interactable = false;
        collidedNPC = "";
    }

    public IEnumerator EndScene()
    {
        yield return new WaitForSeconds(0.8f);
        black.SetTrigger("FadeOutNPC");
        yield return new WaitForSeconds(1);
        Destroy(go_C);
        Destroy(go_M);
        Destroy(go_Vet);
        yield return new WaitForSeconds(1.5f);
        CutsceneDialogManager_QuarantineCamp1.ctrlButtons = true;
        //there should be a trigger of loadscene management in keyframe animation to change scene
    }
}
