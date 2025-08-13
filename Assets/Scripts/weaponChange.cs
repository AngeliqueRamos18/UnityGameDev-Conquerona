using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponChange : MonoBehaviour
{
    private GameObject fireArmWeapon;
    private GameObject meleeWeapon;
    // private GameObject buttonPinkBullet;
    // private GameObject buttonBlueBullet;
    // private GameObject buttonRedBullet;
    private int selectWeaponCase;


    // Start is called before the first frame update
    void Start()
    {
        // Locates the weapons 
        fireArmWeapon = GameObject.Find("GunPrototype");
        meleeWeapon = GameObject.Find("Melee");

        // Locates the Bullet buttons
        // buttonRedBullet = GameObject.Find("btnChangeBulletRed");
        // buttonPinkBullet = GameObject.Find("btnChangeBulletPink");
        // buttonBlueBullet = GameObject.Find("btnChangeBulletBlue");

        // Initializes the selected weapon 
        // (for now wala, sa future vers kung kaya kung pumasok yun player sa ibang scene same parin yun weapon nahawak nila)
        selectWeaponCase = 1;
        SelectWeapon();
    }

    // For website users
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            ChangeWeapon();
        }
    }




    // When the button is pressed, it will cycle between these cases
    private void SelectWeapon()
    {
        switch (selectWeaponCase)
        {
            case 1:
                fireArmWeapon.SetActive(true);
                // buttonPinkBullet.SetActive(true);
                // buttonBlueBullet.SetActive(true);
                // buttonRedBullet.SetActive(true);
                meleeWeapon.SetActive(false);
                break;
            case 2:
                fireArmWeapon.SetActive(false);
                // buttonPinkBullet.SetActive(false);
                // buttonBlueBullet.SetActive(false);
                // buttonRedBullet.SetActive(false);
                meleeWeapon.SetActive(true);
                break;
            default:
                fireArmWeapon.SetActive(false);
                // buttonPinkBullet.SetActive(false);
                // buttonBlueBullet.SetActive(false);
                // buttonRedBullet.SetActive(false);
                meleeWeapon.SetActive(false);
                Debug.Log("default Selected Weapon Case");
                break;
        }
    }

    // Method to change weapon - being pressed by btnChangeWeapon
    public void ChangeWeapon()
    {
        // increments the value of selected weapon variable and updates the selected weapon method
        selectWeaponCase++;
        SelectWeapon();

        // To make the selection of weapons loop between melee and firearm
        if (selectWeaponCase >= 2)
        {
            selectWeaponCase = 0;
        }
    }





}
