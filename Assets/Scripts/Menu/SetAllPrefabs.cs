using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAllPrefabs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Dont forget to comment this if you're going to show the product for the first time

        PlayerPrefs.SetInt("quarantineCamp_Quest", 0);
        PlayerPrefs.SetInt("itt_Quest", 0);
        PlayerPrefs.SetInt("itt_Quest2", 0);
        PlayerPrefs.SetInt("itt_Quest3", 0);
        PlayerPrefs.SetInt("firstTimeQuarantineCamp", 0);
        PlayerPrefs.SetInt("talkJessie", 0);
        PlayerPrefs.SetInt("firstTimeMovementTutorial", 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
