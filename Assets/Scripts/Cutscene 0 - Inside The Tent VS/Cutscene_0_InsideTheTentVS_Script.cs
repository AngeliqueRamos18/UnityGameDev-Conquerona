using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene_0_InsideTheTentVS_Script : MonoBehaviour
{
    public static string eventConvo;
    public static string npcName;
    public bool firstConversationEnd;
    public DialogManager_InsideTheTentVS dialogManager;
    public List<string> obtainedVaccineShots = new List<string>();
    public GameObject dialogSystem;

    public GameObject vaccineShots;
    public bool gotVaccineShots;
    public bool hideVaccineShots;
    public Item item;
    public bool hasShots;
    void Start()
    {
        npcName = "";
        eventConvo = "";
        firstConversationEnd = false;
        hasShots = false;

        hideVaccineShots = false;
        if (PlayerPrefs.HasKey("Inventory"))
        {
            gotVaccineShots = PlayerPrefs.GetString("Inventory").Contains("VaccineShots");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Hides the vaccine shot if you already got it
        if (gotVaccineShots == true && hideVaccineShots == false)
        {
            Inventory.instance.Add(item);
            hasShots = true;
            vaccineShots.SetActive(false);
            hideVaccineShots = true;
        }

        if (eventConvo.Equals("firstConversation") && firstConversationEnd == false)
        {
            StartCoroutine(ShowFirstNarration());
            firstConversationEnd = true;
        }
    }

    public IEnumerator ShowFirstNarration()
    {
        npcName = "";
        yield return new WaitForSeconds(0.1f);
        dialogSystem.SetActive(true);
        dialogManager.Start_Dialog(npcName, obtainedVaccineShots);
    }
}
