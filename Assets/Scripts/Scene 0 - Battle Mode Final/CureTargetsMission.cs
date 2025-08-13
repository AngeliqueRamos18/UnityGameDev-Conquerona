using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CureTargetsMission : MonoBehaviour
{
    public GameObject[] targetList;
    public Text targetCount;
    public static bool completedStage;
    void Start()
    {
        targetList = GameObject.FindGameObjectsWithTag("Enemy_2");
        targetCount.text = (string)targetList.Length.ToString();
        completedStage = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Updates the number of active target case left
        targetList = GameObject.FindGameObjectsWithTag("Enemy_2");
        targetCount.text = (string)targetList.Length.ToString();

        if (targetCount.text.Equals("0")) //DONT FORGET TO TURN IT INTO 0
        {
            completedStage = true;
        }
    }
}
