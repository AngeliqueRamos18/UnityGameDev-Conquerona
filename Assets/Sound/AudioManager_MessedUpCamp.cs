using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AudioManager_MessedUpCamp : MonoBehaviour
{
    private static readonly string backgroundPrefs = "backgroundPrefs";
    private float backgroundFloat;
    public Slider slider;
    public AudioSource backgroundAudio;
    public AudioSource[] listBackgroundAudio;
    private void Awake()
    {
        ContinueSettings();
    }

    private void ContinueSettings()
    {
        //Unlike sa main AudioManager, instead na background sliders value, ang kukunin na is yung PlayerPref value
        backgroundFloat = PlayerPrefs.GetFloat(backgroundPrefs);

        backgroundAudio.volume = backgroundFloat;
        slider.value = backgroundFloat;

        //This function triggers whenever the user moves the slider and set all of the background the same level
        for (int i = 0; i < listBackgroundAudio.Length; i++)
        {
            listBackgroundAudio[i].volume = backgroundFloat;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(backgroundPrefs, slider.value);
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
        backgroundAudio.volume = slider.value;

        //This function triggers whenever the user moves the slider and set all of the background the same level
        for (int i = 0; i < listBackgroundAudio.Length; i++)
        {
            listBackgroundAudio[i].volume = slider.value;
        }
    }
}
