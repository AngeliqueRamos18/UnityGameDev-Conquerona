using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{

    public HealthBar playerHB;
    public float maxHealth = 20;

    public HealthBar healthBar;
   

    // Update is called once per frame
    void Update()
    {
        // Prototype Damage
        if (Input.GetKeyDown(KeyCode.X))
        {
            healthBar.DealDamage(1);
            DealDamageShader();
        }

        // Prototype Heal
        if (Input.GetKeyDown(KeyCode.Z))
        {
            healthBar.RegainHealth(1);
        }

    }


    public void DealDamageShader (){
        Color color = new Color(1, 0, 0, 1f);
        GetComponent<MaterialTint_Damaged>().SetTintColor(color);
    }

    public void RemoveDamageShader()
    {
        Color color = new Color(0, 0, 0, 0f);
        GetComponent<MaterialTint_Damaged>().SetTintColor(color);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("bullet_Target"))
        {
            Enemy_BulletShoot bullet = other.GetComponent<Enemy_BulletShoot>();
            float bulletDamage = bullet.bulletDmg;
            DealDamageShader();
            playerHB.DealDamage(bulletDamage);
            Destroy(other.gameObject);
        }
    }

}
