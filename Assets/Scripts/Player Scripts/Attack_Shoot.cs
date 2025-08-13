using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Attack_Shoot : MonoBehaviour
{

    public Transform shootingPoint;
    public Joystick joystick;
    public GameObject bulletAlcohol;
    // public GameObject bulletRed;
    // public GameObject bulletBlue;
    // public GameObject bulletPink;
    public string bulletType;

    private float timeOfLastShot;
    private float cooldown = 1;
    private Vector2 joystickPosition;
    private Vector2 joystickPositionOrigin; 


    void Start()
    {
        // Sets the Origin of the Joystick Handle and bullet type when initialized
        joystickPositionOrigin = new Vector2(0,0);
        bulletType = "red";
    }

    void Update()
    {  
        // Updates the x and y position of the joystick
        joystickPosition = new Vector2(joystick.Horizontal, joystick.Vertical);

        //Checks if Joystick position is not equals to 0,0 and the cooldown of the bullets
        if (joystickPosition.x != joystickPositionOrigin.x && joystickPosition.y != joystickPositionOrigin.y && Time.time > timeOfLastShot + cooldown)
        {
            //Shoots and records the time of the last shot
            Shoot();
            timeOfLastShot = Time.time;
        }
    }
    
    //Creates an Alcohol bullet
    public void Shoot()
    {   
        
        GameObject bulletCloneAlcohol = Instantiate(bulletAlcohol, shootingPoint.position ,shootingPoint.rotation);
        Rigidbody2D bulletRigidBodyAlcohol = bulletCloneAlcohol.GetComponent<Rigidbody2D>();
        Debug.Log("Bullet");

        // Creates a bullet type and positions it to shooting point
        // switch (bulletType)
        // {
        //     case "red":
        //         GameObject bulletCloneRed = Instantiate(bulletRed, shootingPoint.position ,shootingPoint.rotation);
        //         Rigidbody2D bulletRigidBodyRed = bulletCloneRed.GetComponent<Rigidbody2D>();
        //         Debug.Log("BRed" + bulletType);
        //         break;
        //     case "blue":
        //         GameObject bulletCloneBlue = Instantiate(bulletBlue, shootingPoint.position ,shootingPoint.rotation);
        //         Rigidbody2D bulletRigidBodyBlue = bulletCloneBlue.GetComponent<Rigidbody2D>();
        //         Debug.Log("BBlue" + bulletType);
        //         break;
        //     case "pink":
        //         GameObject bulletClonePink = Instantiate(bulletPink, shootingPoint.position ,shootingPoint.rotation);
        //         Rigidbody2D bulletRigidBodyPink = bulletClonePink.GetComponent<Rigidbody2D>();
        //         Debug.Log("BPink" + bulletType);
        //         break;
        // }
    }

    // Changes the bullet when one of the buttons are selected
    // public void changeBulletRed(){
    //     bulletType = "red";
    // }
    // public void changeBulletBlue(){
    //     bulletType = "blue";
    // }
    // public void changeBulletPink(){
    //     bulletType = "pink";
    // }
}