using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossFightOutro_VolumeSlider : MonoBehaviour
{
    Slider slider;
    private static readonly string backgroundPrefs = "backgroundPrefs";
    public AudioSource backgroundAudio;
    public AudioSource[] listBackgroundAudio;

    //Script for listening on value change slider
    public void Start()
    {
        backgroundAudio = AudioManager.GetInstance().backgroundAudio;
        listBackgroundAudio = AudioManager.GetInstance().listBackgroundAudio;

        //Fetch the Slider GameObject
        slider = GetComponent<Slider>();

        //Add listener for when the state of the Toggle changes, to take action
        slider.onValueChanged.AddListener(delegate {
            SaveSoundSettings(slider);
            UpdateSound(slider);
        });
    }



    private void Update()
    {

    }

    //Output the new state of the Slider
    void SaveSoundSettings(Slider change)
    {
        PlayerPrefs.SetFloat(backgroundPrefs, slider.value);
    }

    void UpdateSound(Slider change)
    {
        backgroundAudio.volume = slider.value;

        for (int i = 0; i < listBackgroundAudio.Length; i++)
        {
            listBackgroundAudio[i].volume = slider.value;
        }
    }
}
