using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InsideTheTruck_SetCurrentVolume : MonoBehaviour
{
    public Slider slider;
    private static readonly string backgroundPrefs = "backgroundPrefs";

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat(backgroundPrefs);
    }
}
