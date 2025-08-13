using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class CutsceneChanger_InsideTheTent3 : MonoBehaviour
{
    public Image black;
    public Animator anim;

    private void Start()
    {

    }

    public void NextScene()
    {
        SceneManager.LoadScene(5);
    }

    public void MessedUpTent()
    {
        SceneManager.LoadScene(10);
    }
}
