using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public AudioSource audioSource;
    private float timer;
    public Item item;
    

    int itt_Quest;

    bool gotVaccineShots;

    private void Update()
    {
        itt_Quest = PlayerPrefs.GetInt("itt_Quest");
    }

    public void OnCollisionEnter2D(Collision2D other) // picks up item by colliding with object
    {
        if (other.gameObject.CompareTag("Player") && itt_Quest == 1 && gotVaccineShots == false)
        {
            PlayerMovement.talking = true;
            Inventory.instance.Add(item);
            PlayerPrefs.SetString("Inventory", "VaccineShots");
            PlayerPrefs.Save();
            Cutscene_0_InsideTheTentVS_Script.eventConvo = "firstConversation";
            //This checks the playerprefab whether the specific key name contains a value
           /* Debug.Log(PlayerPrefs.GetString("Inventory").Contains("VaccineShots"));*/
            gotVaccineShots = true;
            audioSource.Play();
            StartCoroutine(Destroy());
        }
    }

   IEnumerator Destroy()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
        PlayerMovement.talking = false;
    }
}