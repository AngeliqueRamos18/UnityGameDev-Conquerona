using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class SceneSwitch : MonoBehaviour
{
   
    public static bool switchScene;
    public GameObject player;

    void Start()
    {
      
    }

   
    void Update()
    {
        //Always checks if somethign changes in the variables 
        //TODO: Specific it on a certain person if where the player will go 
        Checker();
    }

    void Checker()
    {
        if(DialogManager.doneTalking == true && switchScene == true && NPC.collidedNPC.Equals("NPC_Police2"))
        {
            Debug.Log("Hello");
            SceneManager.LoadScene(2);
        }
    }
}
