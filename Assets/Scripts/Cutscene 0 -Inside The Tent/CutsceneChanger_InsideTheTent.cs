using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CutsceneChanger_InsideTheTent : MonoBehaviour
{
    public Animator black;
    private void Start()
    {
        black.SetTrigger("FadeIn");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(5);
    }
}
