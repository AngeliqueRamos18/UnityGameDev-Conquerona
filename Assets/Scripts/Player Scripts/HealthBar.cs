using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public static bool isGameOver;
    public static bool showGameOver;

    void Start()
    {
        // Sets the Max Value and Starting Value of the slider
        slider = GetComponent<Slider>();
        isGameOver = false;
    }



    void Update()
    {
        if(isGameOver == true && showGameOver == false)
        {
            
        }
    }

    // Reduces the linear healthGameTime value
    public void DealDamage(float damage)
    {
        slider.value -= damage;
    }

    // Increases the linear healthGameTime value
    public void RegainHealth(float health)
    {
        slider.value += health;
    }

    IEnumerator PlayerGameOver()
    {
        //Gameobject of gameover should start here
        Debug.Log("GAME OVER!");
        //
        yield return new WaitForSeconds(5);

        //Restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
