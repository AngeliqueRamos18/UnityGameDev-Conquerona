using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FadeScene : MonoBehaviour
{   public void OnFadeComplete()
    {
        SceneManager.LoadScene(4);
    }
}
