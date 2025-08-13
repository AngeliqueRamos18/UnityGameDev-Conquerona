using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class MainQuest : MonoBehaviour
{

    public int quarantineCamp_Quest;
    public int itt_Quest;
    public int itt_Quest2;
    public int itt_Quest3;
    public static bool vaccineShots;

    public Animator black;
    public Animator blackControl;

    Scene activeScene;
    public static string currentScene;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        activeScene = SceneManager.GetActiveScene();
        currentScene = activeScene.name;

        Debug.Log(currentScene);

        quarantineCamp_Quest = PlayerPrefs.GetInt("quarantineCamp_Quest");
        itt_Quest = PlayerPrefs.GetInt("itt_Quest");
        itt_Quest2 = PlayerPrefs.GetInt("itt_Quest2");
        itt_Quest3 = PlayerPrefs.GetInt("itt_Quest3");

    }

    private void OnCollisionEnter2D(Collision2D player)
    {

        //In Quarantine Camp
        if (currentScene.Equals("Cutscene_0_QuarantineCamp"))
        {
            //Interacting with Inside the Tent entrance
            if (player.gameObject.CompareTag("ITT_Door"))
            {
                //When player completes the quarantine camp cutscene
                //Quarantine camp -> Inside The Tent
                if (quarantineCamp_Quest == 1 && itt_Quest == 0 && itt_Quest2 == 0)
                {
                    StartCoroutine(ITT_DoorIn());
                }

                //When player completes the first cutscene of Inside The Tent / Next Target: Get the Vaccine
                //Quarantine Camp - > Inside the Tent2
                if (quarantineCamp_Quest == 1 && itt_Quest == 1 && itt_Quest2 == 0)
                {
                    StartCoroutine(ITT_DoorIn2());
                }
            }
            //Quarantine Camp -> Inside The Tent Vaccine Shot
            else if (player.gameObject.CompareTag("ITTVS_Door"))
            {
                StartCoroutine(ITTVS_DoorIn());
            }
        }
        //From ITT Tents -> Quarantine Camp
        else if (currentScene.Equals("Cutscene_0_InsideTheTent") || currentScene.Equals("Cutscene_0_InsideTheTent2_NEW"))
        {
            if (player.gameObject.CompareTag("ITT_Door"))
            {
                StartCoroutine(ITT_DoorOut());
            }
        } //From ITT Vaccine Shot -> Quarantine Camp
        else if (currentScene.Equals("Cutscene_0_InsideTheTent_VaccineShot_NEW"))
        {
            if (player.gameObject.CompareTag("ITTVS_Door"))
            {
                StartCoroutine(ITT_DoorOut());
            }
        }
        else if (currentScene.Equals("Scene_0_MessedUpTent_NEW"))
        {
            //When player decides to go outside to messed up quarantine camp
            if (player.gameObject.CompareTag("ITT_Door"))
            {
                StartCoroutine(ITT_DoorOut2());
            }
        }
        else if (currentScene.Equals("Scene_0_MessedUpQuarantineCamp"))
        {
            if (player.gameObject.CompareTag("Battle_Door") && itt_Quest3 == 1)
            {
                StartCoroutine(Battle_DoorIn());
            }
        }
        //Battle Mode Final
        else if (currentScene.Equals("Scene_0_BattleModeFinal"))
        {
            if (player.gameObject.CompareTag("Battle_Door") && CureTargetsMission.completedStage == true)
            {
                StartCoroutine(Door_BossFight());
            }
        }
    }

    IEnumerator Battle_DoorIn()
    {
        blackControl.SetBool("FadeOutBattle", true);
        black.SetBool("FadeOutBattle", true);
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(12);
    }
    IEnumerator ITT_DoorOut()
    {
        black.SetBool("FadeOut", true);
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(4);
    }

    IEnumerator ITT_DoorOut2()
    {
        blackControl.SetBool("FadeOut", true);
        black.SetBool("FadeOut", true);
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(11);
    }

    IEnumerator ITT_DoorIn()
    {
        black.SetBool("FadeOut", true);
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(5);
    }

    IEnumerator ITT_DoorIn2()
    {
        black.SetBool("FadeOut", true);
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(7);
    }

    IEnumerator ITTVS_DoorIn()
    {
        black.SetBool("FadeOut", true);
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(6);
    }

    IEnumerator Door_BossFight()
    {
        blackControl.SetBool("FadeOut", true);
        black.SetBool("FadeOut", true);
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(13);
    }
}
