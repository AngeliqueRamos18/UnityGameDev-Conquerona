using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetDamageScript : MonoBehaviour
{
    public HealthBar hb;
    public PlayerDamaged playerDamaged;
    public Target_MainFunctions_S1 target_MainFunctions_S1;
    public bool isCollided;
    private float dmg;
    float currentTime = 0f;
    float predictedTime = 0f;
    float convertedtime = 0f;
    float startingTime = 10f;
    float coolDown = 1f;
    public bool isGameOver;
    private bool activeCase_Target_S1;


    // Start is called before the first frame update
    void Start()
    {
        //hb.slider = GetComponent<Slider>();
        isCollided = false;
        isGameOver = false;
        dmg = 0.01f;
        // target_MainFunctions_S1 = GetComponent<Target_MainFunctions_S1>();
        // bool activeCase_Target_S1 = target_MainFunctions_S1.isActiveCase;
    }

    // Update is called once per frame
    void Update()
    {
    //Debug.Log(target_MainFunctions_S1.isActiveCase);
        if (isCollided)
        {
            if (target_MainFunctions_S1.isActiveCase == true)
            {
                    Debug.Log("DamagingPlayer");
                    StartCoroutine(DamagePerSecond());
            }
        }


        if (hb.slider.value < 1 && isGameOver != true)
        {
            HealthBar.isGameOver = true;
            StartCoroutine(ShowGameOver());
        }
    }

    private void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.CompareTag("Player"))
        {
            isCollided = true;
            Debug.Log(enemy);
        }
    }

    private void OnCollisionExit2D(Collision2D enemy)
    {
        isCollided = false;
        currentTime = 0f;
        predictedTime = 3;
    }

    IEnumerator DamagePerSecond()
    {
        yield return new WaitForSeconds(0.1f);
        if (isCollided == true)
        {
            hb.slider.value -= dmg;
            Debug.Log("Is collided: " + isCollided);
            playerDamaged.DealDamageShader();
            StartCoroutine(Blinking());
        }
    }

    IEnumerator ShowGameOver()
    {
        yield return new WaitForSeconds(0.1f);
        isGameOver = true;
        Debug.Log("Game OVER!!");
    }

    IEnumerator Blinking()
    {
        yield return new WaitForSeconds(0.5f);
        playerDamaged.RemoveDamageShader();
    }
}
