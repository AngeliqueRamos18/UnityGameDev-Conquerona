using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class CutsceneChanger_InsideTheTent2 : MonoBehaviour
{
    public Animator white;

    private void Start()
    {

    }

    public void NextScene()
    {
        SceneManager.LoadScene(8);
    }


}
