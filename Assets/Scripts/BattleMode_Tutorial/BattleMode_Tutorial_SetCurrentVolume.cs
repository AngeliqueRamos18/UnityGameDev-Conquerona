using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleMode_Tutorial_SetCurrentVolume : MonoBehaviour
{
    public Slider slider;
    private static readonly string backgroundPrefs = "backgroundPrefs";
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat(backgroundPrefs);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
