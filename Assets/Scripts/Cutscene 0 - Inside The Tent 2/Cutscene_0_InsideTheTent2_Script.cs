using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


public class Cutscene_0_InsideTheTent2_Script : MonoBehaviour
{
    public static int sequencing;
    public static string eventConvo;
    public static string npcName;
    public static bool talkVeteran;
    public static bool talkSis;
    public bool firstConversationEnd;
    public bool secondConversationEnd;
    public bool endSceneStopper;
    public Animator black;
    public CutsceneDialogManager_InsideTheTent2 dialogManager;
    public List<string> conversation = new List<string>();
    public List<string> secondConversation = new List<string>();
    public List<string> sisConversation1 = new List<string>();
    public List<string> vetConversation = new List<string>();
    public GameObject dialogSystem;

    public Button btnTalk;
    public PlayerMovement playerMovement;
    public static string collidedNPC;
    public static bool ITT2_Quest;
    public static bool ITT2_Quest2;
    public static bool chatSickSis;
    public static bool chatVeteran;
    public bool vaccineShots;

    public bool hasShots;
    public Item item;

    Scene activeScene;
    string currentScene;

    void Start()
    {
        npcName = "Veteran";
        eventConvo = "";
        firstConversationEnd = false;
        secondConversationEnd = false;
        talkSis = false;
        endSceneStopper = false;
        sequencing = 0;
        //Responsible for triggering the coroutine when talking to veteran
        talkVeteran = false;
        //checks whether if the cutscene is done or not
        ITT2_Quest = false;
        ITT2_Quest2 = false;
        btnTalk.interactable = false;
        chatSickSis = true;
        chatVeteran = false;
        hasShots = false;
        vaccineShots = PlayerPrefs.GetString("Inventory").Contains("VaccineShots");
        currentScene = "";


    }

    private void Update()
    {
        activeScene = SceneManager.GetActiveScene();
        currentScene = activeScene.name;

        vaccineShots = PlayerPrefs.GetString("Inventory").Contains("VaccineShots");

        //Code for getting the vaccine in the bag
        if (currentScene.Equals("Cutscene_0_InsideTheTent2_NEW") && vaccineShots == true && hasShots == false )
        {
            Inventory.instance.Add(item);
            hasShots = true;
        }
        else
        {
            Debug.Log("No vaccine yet!");
        }
        //Main quest dialogues
        if (talkVeteran == true && firstConversationEnd == false)
        {
            StartCoroutine(ShowFirstNarration());
            firstConversationEnd = true;
        }

        if (eventConvo.Equals("secondConversation") && talkSis == true && secondConversationEnd == false)
        {
            //Ditong part naman dapat makausap na ng user si Robert's sister
            StartCoroutine(ShowSecondNarration());
            //Prevents this function from getting stuck in the same dialogue
            secondConversationEnd = true;
        }

        //Temporary dialogues ==================================
        if (chatSickSis == false)
        {
            //This refers when the player talks to sister first rather the veteran
            StartCoroutine(ChatSickSis());
            chatSickSis = true;
        }

        if (chatVeteran == true)
        {
            StartCoroutine(ChatVeteran());
            chatVeteran = false;
        }


    }

    public IEnumerator ShowFirstNarration()
    {
        yield return new WaitForSeconds(0.1f);
        btnTalk.interactable = false;
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, conversation);
    }

    public IEnumerator ShowSecondNarration()
    {
        npcName = "Robert's Sister";
        yield return new WaitForSeconds(0.1f);
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, secondConversation);
    }

    //Temporary Dialogue of Sis in Sick State
    public IEnumerator ChatSickSis()
    {
        npcName = "Robert's Sister";
        yield return new WaitForSeconds(0.1f);
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, sisConversation1);
    }

    public IEnumerator ChatVeteran()
    {
        npcName = "Veteran";
        yield return new WaitForSeconds(0.1f);
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, vetConversation);
    }



    public void StartTalk()
    {
        //Checks if the btn talk is visible
        if (btnTalk.interactable == true)
        {
            btnTalk.interactable = false; //Hides the appearance of the talk button after clicking on it
            if (collidedNPC.Equals("NPC_Veteran") && ITT2_Quest == false)
            {
                //Sets the talkfrontliner to true which means it will activate the cutscene dialog
                talkVeteran = true;
                ITT2_Quest = true;
            }

            if (collidedNPC.Equals("NPC_VeteranChat"))
            {
                chatVeteran = true;
            }

            //Sis Conversation

            if (collidedNPC.Equals("NPC_Sis"))
            {
                //Sinasabi ditong part is kapag tapos mo nang kausapin si veteran 
                if (ITT2_Quest == true && ITT2_Quest2 == false)
                {
                    talkSis = true;
                    ITT2_Quest2 = true;
                }
                else if (ITT2_Quest == false)
                {
                    //State na kapag hindi pa kinakausap ng player yung veteran
                    chatSickSis = false;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.CompareTag("NPC_Veteran"))
        {
            if (vaccineShots == true)
            {
                //When the player has gotten the vaccine
                btnTalk.interactable = true;
                eventConvo = "firstConversation";
                npcName = "Veteran";
                collidedNPC = "NPC_Veteran";
                Debug.Log("Colliding with: " + npcName);

            }
            else if (vaccineShots == false)
            {
                //When the player hasnt gotten the vaccine
                eventConvo = "chatVeteran";
                btnTalk.interactable = true;
                npcName = "Veteran";
                collidedNPC = "NPC_VeteranChat";
            }

        }

        if (player.gameObject.CompareTag("NPC_Sis") && ITT2_Quest == true)
        {
            btnTalk.interactable = true;
            eventConvo = "secondConversation";
            npcName = "Robert's Sister";
            collidedNPC = "NPC_Sis";
        }
        else if (player.gameObject.CompareTag("NPC_Sis") && ITT2_Quest == false)
        {

            //To make sure that the main dialogue doesnt get involved to the temporary dialogue
            btnTalk.interactable = true;
            eventConvo = "chatSickSis";
            npcName = "Robert's Sister";
            collidedNPC = "NPC_Sis";
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        btnTalk.interactable = false;
        collidedNPC = "";
    }
}
