using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    //Try not to make the variable and value the same in readonly string, playerprefs will not work
    private static readonly string firstPlay = "FirstPlay";
    private static readonly string backgroundPrefs = "backgroundPrefs";
    private static readonly string currentBG = "currentBG";
    private int firstPlayInt;
    public static Slider backgroundSlider;
    private float backgroundFloat;
    public AudioSource backgroundAudio;
    public AudioSource[] listBackgroundAudio;
    Scene activeScene;
    string currentScene;
    public static bool changingScene;
    public static bool changingScene2;
    public static bool changingScene3;
    public static bool changingScene4;
    public static bool changingScene5;
    public static bool changingScene6;
    public static bool changingScene7;
    public static bool changingScene8;
    public static bool changingScene9;
    public static bool changingScene10;
    public static bool changingScene11;
    public static string currentMusic;


    private static AudioManager instance;

    public static AudioManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        backgroundSlider = GameObject.Find("SceneChanger").transform.Find("Canvas").transform.Find("InGameSettings").transform.Find("volume").GetComponent<Slider>();

        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else if (instance != this)
        {

            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }



    private void Start()
    {
        changingScene = false;
        changingScene2 = false;
        changingScene4 = false;
        changingScene5 = false;
        changingScene6 = false;
        changingScene7 = false;
        changingScene8 = false;
        changingScene9 = false;
        changingScene10 = false;
        changingScene11 = false;

        //This function checks whether it's your first time to play the game, set default level 
        firstPlayInt = PlayerPrefs.GetInt(firstPlay);

        if (firstPlayInt == 0)
        {
            backgroundFloat = .50f;
            backgroundSlider.value = backgroundFloat;
            PlayerPrefs.SetFloat(backgroundPrefs, backgroundFloat);
            PlayerPrefs.SetFloat(firstPlay, -1);
        }
        else
        {
            //Gets the last value if the game is not opened for the first time
            backgroundFloat = PlayerPrefs.GetFloat(backgroundPrefs);
            backgroundSlider.value = backgroundFloat;
        }


    }

    private void Update()
    {
        Debug.Log(changingScene);
        activeScene = SceneManager.GetActiveScene();
        currentScene = activeScene.name;
        currentMusic = PlayerPrefs.GetString(currentBG);

        //This will get the name of current active scene
        if (currentScene.Equals("Menu") && changingScene == false)
        {
            changingScene2 = false;
            changingScene3 = false;
            changingScene4 = false;
            changingScene5 = false;
            changingScene6 = false;
            changingScene7 = false;
            changingScene8 = false;
            changingScene9 = false;
            changingScene10 = false;
            changingScene11 = false;
            //Checks if the song is not the same when they go back to menu
            if (!currentBG.Equals("MenuBG"))
            {
                PlayerPrefs.SetString(currentBG, "MenuBG");
                backgroundAudio.clip = listBackgroundAudio[0].clip;
                backgroundAudio.Play();
            }

            backgroundSlider = GameObject.Find("SceneChanger").transform.Find("Canvas").transform.Find("InGameSettings").transform.Find("volume").GetComponent<Slider>();
            changingScene = true;
        }

        if (currentScene.Equals("Cutscene_0_InsideTheTruck") && changingScene2 == false)
        {
            //Adds reference to the dontdestroyonload to the missing slider when scene is loaded
            if (backgroundSlider == null)
            {
                backgroundSlider = GameObject.Find("MainCanvas").transform.Find("InGameSettings").transform.Find("volume2").GetComponent<Slider>();
            }

            changingScene2 = true;
        }

        if (currentScene.Equals("Cutscene_0_OutsideTheTruck") && changingScene3 == false)
        {
            if (!currentBG.Equals("QuarantineCampBG"))
            {
                PlayerPrefs.SetString(currentBG, "QuarantineCampBG");
                backgroundAudio.clip = listBackgroundAudio[1].clip;
                backgroundAudio.Play();
            }

            if (backgroundSlider == null)
            {
                backgroundSlider = GameObject.Find("MainCanvas").transform.Find("InGameSettings").transform.Find("volume3").GetComponent<Slider>();
            }

            changingScene3 = true;
        }

        if (currentScene.Equals("Cutscene_0_QuarantineCamp") && changingScene4 == false)
        {
            if (!currentBG.Equals("QuarantineCampBG"))
            {
                PlayerPrefs.SetString(currentBG, "QuarantineCampBG");
                backgroundAudio.clip = listBackgroundAudio[1].clip;
            }

            if (backgroundSlider == null)
            {
                backgroundSlider = GameObject.Find("CanvasButtons").transform.Find("InGameSettings").transform.Find("volume4").GetComponent<Slider>();
            }

            changingScene4 = true;
        }

        if (currentScene.Equals("Cutscene_0_InsideTheTent") && changingScene5 == false)
        {
            if (!currentBG.Equals("QuarantineCampBG"))
            {
                PlayerPrefs.SetString(currentBG, "QuarantineCampBG");
                backgroundAudio.clip = listBackgroundAudio[1].clip;
            }

            if (backgroundSlider == null)
            {
                backgroundSlider = GameObject.Find("CanvasButtons").transform.Find("InGameSettings").transform.Find("volume5").GetComponent<Slider>();
            }

            changingScene5 = true;
        }


        if (currentScene.Equals("Cutscene_0_InsideTheTent2") && changingScene6 == false)
        {
            if (!currentBG.Equals("QuarantineCampBG"))
            {
                PlayerPrefs.SetString(currentBG, "QuarantineCampBG");
                backgroundAudio.clip = listBackgroundAudio[1].clip;
            }

            if (backgroundSlider == null)
            {
                backgroundSlider = GameObject.Find("CanvasButtons").transform.Find("InGameSettings").transform.Find("volume6").GetComponent<Slider>();
            }

            changingScene6 = true;
        }

        if (currentScene.Equals("BattleMode_Tutorial") && changingScene7 == false)
        {
            if (!currentBG.Equals("BattleModeBG"))
            {
                PlayerPrefs.SetString(currentBG, "BattleModeBG");
                backgroundAudio.clip = listBackgroundAudio[2].clip;
                backgroundAudio.Play();
            }

            if (backgroundSlider == null)
            {
                backgroundSlider = GameObject.Find("CanvasButtons").transform.Find("InGameSettings").transform.Find("volume").GetComponent<Slider>();
            }

            changingScene7 = true;
        }

        if (currentScene.Equals("Cutscene_0_InsideTheTent3_NEW") && changingScene8 == false)
        {
            if (!currentBG.Equals("QuarantineCampBG"))
            {
                PlayerPrefs.SetString(currentBG, "QuarantineCampBG");
                backgroundAudio.clip = listBackgroundAudio[1].clip;
                backgroundAudio.Play();
            }

            if (backgroundSlider == null)
            {
                backgroundSlider = GameObject.Find("CanvasButtons").transform.Find("InGameSettings").transform.Find("volume").GetComponent<Slider>();
            }

            changingScene8 = true;
        }

        //Messed Up Tent
        if (currentScene.Equals("Scene_0_MessedUpTent_NEW") && changingScene9 == false)
        {
            if (!currentBG.Equals("MessedUpBG"))
            {
                PlayerPrefs.SetString(currentBG, "MessedUpBG");
                backgroundAudio.clip = listBackgroundAudio[4].clip;
                backgroundAudio.Play();
            }

            if (backgroundSlider == null)
            {
                backgroundSlider = GameObject.Find("CanvasButtons").transform.Find("InGameSettings").transform.Find("volume").GetComponent<Slider>();
            }

            changingScene9 = true;
        }

        if (currentScene.Equals("Scene_0_BattleModeFinal") && changingScene10 == false)
        {
            if (!currentBG.Equals("BattleModeBG"))
            {
                PlayerPrefs.SetString(currentBG, "BattleModeBG");
                backgroundAudio.clip = listBackgroundAudio[2].clip;
                backgroundAudio.Play();
            }

            if (backgroundSlider == null)
            {
                backgroundSlider = GameObject.Find("CanvasButtons").transform.Find("InGameSettings").transform.Find("volume").GetComponent<Slider>();
            }

            changingScene10 = true;
        }

        if (currentScene.Equals("Cutscene_0_BossFightOutro_NEW") && changingScene11 == false)
        {
            if (!currentBG.Equals("EndCreditsBG"))
            {
                PlayerPrefs.SetString(currentBG, "EndCreditsBG");
                backgroundAudio.clip = listBackgroundAudio[3].clip;
                backgroundAudio.Play();
            }

            if (backgroundSlider == null)
            {
                backgroundSlider = GameObject.Find("CanvasButtons").transform.Find("InGameSettings").transform.Find("volume").GetComponent<Slider>();
            }

            changingScene11 = true;
        }

        Debug.Log("Current scene: " + currentScene);
        Debug.Log("Current BG: " + PlayerPrefs.GetString(currentBG));
    }

    public void ResetChangingScene()
    {
        AudioManager.changingScene = false;
    }


    public void SaveSoundSettings()
    {
        //Saves the actual value before losing focus on the game or exiting
        //Saves the sounds too if you're going to play the button or exit 
        PlayerPrefs.SetFloat(backgroundPrefs, backgroundSlider.value);
    }

    private void OnApplicationFocus(bool focus)
    {
        //This will function whenever the app loses focus
        if (!focus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;

        //This function triggers whenever the user moves the slider and set all of the background the same level
        for (int i = 0; i < listBackgroundAudio.Length; i++)
        {
            listBackgroundAudio[i].volume = backgroundSlider.value;
        }
    }
}
