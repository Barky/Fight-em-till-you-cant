using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float realHealth;

    private Animator anim;

    private bool playerDead;
    private bool playerHit;

    // private Slider HealthSlider;
    // private Text HealthText;

    private BossHealth bossHealth;
    private Transform Boss;
    private bool victory;

    private string ANIM_ATTACKED = "Attacked";
    private string ANIM_DEAD = "Dead";
    private string ANIM_VICTORY = "Victory";

    private void Awake()
    {
        anim = GetComponent<Animator>();
        
        //healthslider
        //healthtext
        
        // set slider and text
    
        Boss = GameObject.FindGameObjectWithTag("Boss")?.transform;
        bossHealth = Boss?.GetComponent<BossHealth>();
    }

    private void Update()
    {
        
        if (realHealth <= 0)
        {
            realHealth = 0;
            PlayerDying();
        }

        if (playerDead)
        {
            StopDeadAnim();
        }

        if (realHealth >= 100)
        {
            realHealth = 100;
        }

        // if (bossHealth.realHealth <= 0)
        // {
        //     Victory();
        // }

        if (victory)
        {
            StopVictoryAnim();
        }
    }

    void PlayerDying()
    {
        playerDead = true;
        anim.SetBool(ANIM_DEAD, true);
        anim.SetBool(ANIM_ATTACKED, false);
    }

    void StopDeadAnim()
    {
       if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Dying"))
        {
            anim.SetBool(ANIM_DEAD, false);
        }
    }

    public void TakeDamage(float amount)
    {
        realHealth -= amount;
        Debug.LogError(realHealth);
        if (realHealth <= 0)
        {
            realHealth = 0;
        }

        if (amount > 0)
        {
            // healthtext = realhealth
            // healthslider.value = realhealth
            playerHit = true;
        }
    }

    void Victory()
    {
        anim.SetBool(ANIM_VICTORY, true);
        victory = true;
    }

    void StopVictoryAnim()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Victory"))
        {
            anim.SetBool(ANIM_VICTORY, false);
        }
    }
}
