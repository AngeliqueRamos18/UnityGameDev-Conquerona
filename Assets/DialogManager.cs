using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
   /* private PlayerMovement playerMovement;*/
    public GameObject dialogPanel;
    public Text npcNameText;
    public Text dialogText;
    public GameObject Controller;
    public GameObject BattleButtons;
    public Button endDialogueButton;
    public Button nextDialogueButton;
    private List<string> conversation;
    private int convoIndex;
    public GameObject talking; //This variable is responsible for checking whether the player is currently talking to a NPC
    public static bool doneTalking;


    private void Start()
    {
       
        dialogPanel.SetActive(false);
        convoIndex = 0;
        Controller.SetActive(true);
        BattleButtons.SetActive(true);
        //Para maconnect ang variable na talking mula sa PlayerMovement script
        /*playerMovement = talking.GetComponent<PlayerMovement>();*/
        //Sets the variable switchScene frrom another script to false
        SceneSwitch.switchScene = false;
        doneTalking = false;

    }

    public void Start_Dialog(string _npcName, List<string> _convo)
    {
        npcNameText.text = _npcName;
        conversation = new List<string>(_convo);
        dialogPanel.SetActive(true);
        convoIndex = 0;
        ShowText();
        Controller.SetActive(false);
        BattleButtons.SetActive(false);
        PlayerMovement.talking = true; //sets the talking to true kapag nag start na dialog
    }

    public void StopDialog()
    {
        Controller.SetActive(true);
        BattleButtons.SetActive(true);
        dialogPanel.SetActive(false);
        nextDialogueButton.interactable = true;
        endDialogueButton.interactable = false;
        PlayerMovement.talking = false;
    }

    private void ShowText()
    {
        dialogText.text = conversation[convoIndex];
    }

    public void Next()
    {
        if (convoIndex < conversation.Count - 1)
        {
            convoIndex += 1;
            ShowText();
        }
        else
        {
            nextDialogueButton.interactable = false;
            endDialogueButton.interactable = true;
        }
    }


    //Functions for clicking the End Conversation in the last line of the dialog
    public void Hide()
    {
        Controller.SetActive(true);
        BattleButtons.SetActive(true);
        dialogPanel.SetActive(false);
        nextDialogueButton.interactable = true;
        endDialogueButton.interactable = false;
        PlayerMovement.talking = false;
        doneTalking = true;

        if (NPC.collidedNPC.Equals("NPC_Police2"))
        {
            SceneSwitch.switchScene = true;
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        doneTalking = false;
    }

}
