using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneChanger_InsideTheTruckGoHome : MonoBehaviour
{
    public void GoHome()
    {
        SceneManager.LoadScene(1);
    }
}
