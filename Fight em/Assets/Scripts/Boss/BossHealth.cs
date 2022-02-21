using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float realHealth;

    public AudioClip deadSound;
    private AudioSource audioSource;

    private Animator anim;
    private bool isDead;

    private CapsuleCollider col;

    private string ANIM_DEATH = "Death";
    private string ANIM_BASE_DEATH = "Base Layer.DEATH";
    private void Awake()
    {
        col = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isDead)
        {
            StopDeadAnimation();
        }
    }

    void BossDie()
    {
        anim.SetBool(ANIM_DEATH, true);
        isDead = true;
        col.enabled = false;
        audioSource.PlayOneShot(deadSound);
    }

    public void BossDamage(float amount)
    {
        realHealth -= amount;
        Debug.LogError("boss took damage -"+realHealth);
        if (realHealth <= 0)
        {
            realHealth = 0;
            BossDie();
        }
    }

    void StopDeadAnimation()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(ANIM_BASE_DEATH))
        {
            anim.SetBool(ANIM_DEATH,false);
        }
    }
    
}
