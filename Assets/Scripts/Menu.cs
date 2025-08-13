using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{


    public GameObject container;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenSettings()
    {
        container.active = true;
    }

    public void CloseSettings()
    {
        container.active = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
