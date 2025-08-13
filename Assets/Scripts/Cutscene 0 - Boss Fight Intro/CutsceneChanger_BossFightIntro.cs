using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class CutsceneChanger_BossFightIntro : MonoBehaviour
{
    public Image red;
    public Animator entryAnim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterBoss()
    {
        SceneManager.LoadScene(14);
    }
}
