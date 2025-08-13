using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class Menu_SetVolume : MonoBehaviour
{
    private static readonly string firstPlay = "FirstPlay";
    private static readonly string BackgroundPref = "BackgroundPref";
    private int firstPlayInt;
    public  AudioMixer mixer;
    public Slider slider;
    public float backgroundFloat;

    private void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(firstPlay);

        if(firstPlayInt == 0)
        {
            //Checks if the player have just opened the game for the first time
            backgroundFloat = .50f;
            slider.value = backgroundFloat;
            PlayerPrefs.SetFloat(BackgroundPref, backgroundFloat);

            //Removes the saved first time progress
            PlayerPrefs.SetInt(firstPlay, -1);
        }
        else
        {
            //Gets the current value if it's not the first time 
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            slider.value = backgroundFloat; 
        }
    }
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }

    public void SaveSoundSettings()
        
    {
        PlayerPrefs.SetFloat(BackgroundPref, slider.value);
    }

    //Responsible for checking whether you're still in focus or not it will trigger a function
    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveSoundSettings();
        }
    }
}
 