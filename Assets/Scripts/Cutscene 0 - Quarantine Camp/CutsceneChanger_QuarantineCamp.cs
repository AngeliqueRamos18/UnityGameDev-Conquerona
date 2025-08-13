using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class CutsceneChanger_QuarantineCamp : MonoBehaviour
{
    public Animator black;
    private void Start()
    {
        black.SetTrigger("FadeIn");
    }
}
