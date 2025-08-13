using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Trigger_btnDown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Animator animator;

    private string currentState;

    // Animation State
    const string player_WalkDown = "Prototype_WalkDown";
    const string player_Idle = "Player_Idle";


    public void OnPointerDown(PointerEventData eventData)
    {
        /*Debug.Log("T_Down_New");*/
        ChangeAnimationState(player_WalkDown);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
/*        Debug.Log("F_Down_New");*/
        ChangeAnimationState(player_Idle);
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }
}