using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCVersion : MonoBehaviour
{
    public Canvas controls;
    public bool pcVersion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pcVersion == true)
        {
            controls.renderMode = RenderMode.WorldSpace;
        }
        else
        {
            controls.renderMode = RenderMode.ScreenSpaceOverlay;
        }
    }
}
