using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Trigger_btnTopLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Animator animator;

    private string currentState;

    // Animation State
    const string player_WalkLeft = "Prototype_WalkLeft";
    const string player_Idle = "Player_Idle";
    
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("T_TopLeft_New");
        ChangeAnimationState(player_WalkLeft);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("F_TopLeft_New");
        ChangeAnimationState(player_Idle);
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }

}
