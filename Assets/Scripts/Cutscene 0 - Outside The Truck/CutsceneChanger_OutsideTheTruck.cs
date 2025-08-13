using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class CutsceneChanger_OutsideTheTruck : MonoBehaviour
{
    public Animator black2;
    public void EndScene()
    {
        SceneManager.LoadScene(4);
    }
}
