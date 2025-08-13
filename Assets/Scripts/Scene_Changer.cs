using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Scene_Changer : MonoBehaviour
{
    public Image black;
    public Animator anim;
    public void StartGame()
    {
        anim.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(2);
    }


}
