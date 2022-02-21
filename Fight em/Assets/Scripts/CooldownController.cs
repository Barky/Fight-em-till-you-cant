using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownController : MonoBehaviour
{
    public int waitTime;
    private int fadeTime;
    
    private Image fadeImg;
    private Text waitText;

    private bool canFade;

    private GameObject cooldownPanel;

    private void Awake()
    {
        cooldownPanel = transform.GetChild(0).gameObject;
        waitText = cooldownPanel.GetComponentInChildren<Text>();
        
        waitText.text = waitTime.ToString();
        fadeTime = waitTime;

        fadeImg = cooldownPanel.GetComponent<Image>();
        
        cooldownPanel.SetActive(false);
    }


    private void Update()
    {
        FadeOut();
    }


    public void StartCoolDown()
    {
        cooldownPanel.SetActive(true);
        waitText.text = waitTime.ToString();

        Color temp = fadeImg.color;
        temp.a = 1f;

        fadeImg.color = temp;
        StartCoroutine(Countdown());
    }

    void FadeOut()
    {
        if (canFade)
        {
            Color temp = fadeImg.color;
            temp.a -= (Time.deltaTime / fadeTime) / 2f;
            fadeImg.color = temp;
        }
    }
    IEnumerator Countdown()
    {
        canFade = true;
        yield return new WaitForSeconds(1f);
        waitTime--;

        if (waitTime != -1)
        {
            waitText.text = waitTime.ToString();
            StartCoroutine(Countdown());
        }
        else
        {
            waitTime = fadeTime;
            cooldownPanel.SetActive(false);
            canFade = false;
        }
    }
    
}
