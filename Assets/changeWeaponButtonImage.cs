using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeWeaponButtonImage : MonoBehaviour
{

    private int weaponChangeButtonState;

    [SerializeField]
    private Sprite[] switchWeaponChangeButton;
    private Image currentWeaponChangeButton;


    // Start is called before the first frame update
    void Start()
    {
        // First Stage is Gun pero pag may save prefs kailangan isave
        weaponChangeButtonState = 0;

        // gets the image of the button
        currentWeaponChangeButton = GetComponent<Button>().image;

        // sets the image as the first image in the array
        currentWeaponChangeButton.sprite = switchWeaponChangeButton[weaponChangeButtonState];
    }

    public void ChangeWeaponButton()
    {
        // cycles between 1 and 0
        weaponChangeButtonState = 1 - weaponChangeButtonState;
        // sets the current value of the weaponChangeButtonState to the corresponding sprite
        currentWeaponChangeButton.sprite = switchWeaponChangeButton[weaponChangeButtonState];
    }

}
