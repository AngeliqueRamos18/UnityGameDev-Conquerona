using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    public float bulletSpeed;
    public int bulletDmg;
    private Vector2 direction;
    //public Target_MainFunctions_S1 target_MainFunctions_S1;
    public bool activeCase_Target_S1;
    
    // Start is called before the first frame update
    void Start()
    {
        // Finds the direction GameObject and the rotation of the bullet
        direction = GameObject.Find("Direction").transform.position;
        transform.position = GameObject.Find("ShootingPoint").transform.position;
        bulletDmg = 1;
        Destroy (gameObject, 3f);
        //bool activeCase_Target_S1 = target_MainFunctions_S1.isActiveCase;
    }

    // Update is called once per frame
    void Update()
    {
        // moves the bullet towards the direction GameObject
        transform.position = Vector2.MoveTowards(transform.position, direction, bulletSpeed * Time.deltaTime);
    }

    // void OnTriggerEnter2D(Collider2D hitInfo)
    // {
    //     // Note: Switch Case to see which Enemy gets hit
    //     // Gets the functions of the enemy script 
    //     Target_MainFunctions_S1 enemy = hitInfo.GetComponent<Target_MainFunctions_S1>();
    //     if (enemy != null)
    //     {
    //         if (activeCase_Target_S1 == true)
    //         {
    //             enemy.TakeDamage(bulletDmg);
    //         }
            
    //     }
    //     Destroy(gameObject);

       
    // }
}
