using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackButtons : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private PlayerAttacks playerAttacks;

    private void Awake()
    {
        playerAttacks = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttacks>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name == "AttackButton")
        {
            playerAttacks.AttackButtonClick();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (gameObject.name == "AttackButton")
        {
            playerAttacks.AttackButtonRelease();
        }
    }
}
