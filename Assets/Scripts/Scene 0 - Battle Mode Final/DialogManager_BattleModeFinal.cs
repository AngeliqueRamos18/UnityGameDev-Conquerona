using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager_BattleModeFinal : MonoBehaviour
{
    public GameObject dialogPanel;
    public DialogManager_BattleModeFinal dialogManager;
    public Text dialogText;
    public Button nextDialogueButton;
    private List<string> conversation;
    private int convoIndex;
    public GameObject ctrlButtons;
    public GameObject battleButtons;
    public PlayerMovement pcControl;
    void Start()
    {
        convoIndex = 0;
        pcControl.enabled = true;
    }

    public void Start_Dialog(string _npcName, List<string> _convo)
    {
        ctrlButtons.SetActive(false);
        battleButtons.SetActive(false);
        pcControl.enabled = false;
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
    }

    public void Hide()
    {
        dialogPanel.SetActive(false);
        nextDialogueButton.interactable = true;
    }

    public void Next()
    {
        battleButtons.SetActive(true);
        dialogPanel.SetActive(false);
        pcControl.enabled = true;
        ctrlButtons.SetActive(true);
    }
}
