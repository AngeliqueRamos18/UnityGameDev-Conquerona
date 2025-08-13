using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class BattleMode_Script : MonoBehaviour
{
    public DialogManager_BattleMode_Tutorial dialogManager;
    public static int sequencing;
    public static string eventConvo;
    public static string npcName;
    public List<string> firstDialogue = new List<string>();
    public List<string> secondDialogue = new List<string>();
    public List<string> thirdDialogue = new List<string>();
    public GameObject dialogSystem;
    public bool firstPartEnd;
    public bool secondPartEnd;
    public bool thirdPartEnd;

    void Start()
    {
        npcName = "Veteran";
        eventConvo = "firstPart";
        sequencing = 0;
        firstPartEnd = false;
        secondPartEnd = false;
        thirdPartEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (eventConvo.Equals("firstPart") && firstPartEnd == false)
        {
            StartCoroutine(ShowFirstDialog());
            firstPartEnd = true;
        }
        
        if (eventConvo.Equals("secondPart") && secondPartEnd == false)
        {
            StartCoroutine(ShowSecondDialog());
            secondPartEnd = true;
        }

        if(eventConvo.Equals("thirdPart") && thirdPartEnd == false)
        {
            StartCoroutine(ShowThirdDialog());
            thirdPartEnd = true;
        }
    }

    IEnumerator ShowFirstDialog()
    {
        yield return new WaitForSeconds(1);
        dialogManager.Start_Dialog(npcName, firstDialogue);
    }
    IEnumerator ShowSecondDialog()
    {
        yield return new WaitForSeconds(2);
        dialogManager.Start_Dialog(npcName, secondDialogue);
    }

    IEnumerator ShowThirdDialog()
    {
        yield return new WaitForSeconds(1);
        dialogManager.Start_Dialog(npcName, thirdDialogue);
    }
}
