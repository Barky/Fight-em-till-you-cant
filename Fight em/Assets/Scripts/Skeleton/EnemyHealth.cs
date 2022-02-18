using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float realHealth;

    private AudioSource audi;
    public AudioClip enemyDeadSound;

    private bool enemyDead;
    private Animator anim;
    private bool enemyHit;

    public GameObject AttackPoint;

    public GameObject deadEffect;
    public Transform deadEffectPoint;

    private string DEAD_ANIM = "Dead";
    private string ATTACKED_ANIM = "BeAttacked";
    private string ATTACK_ANIM = "Attack";
    private void Awake()
    {
        audi = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (enemyDead)
        {
            StopDeadAnim();
        }

        if (enemyHit)
        {
            EnemyAttacked();
        }

        if (!enemyHit)
        {
            StopEnemyHit();
        }
    }

    void EnemyDying()
    {
        anim.SetBool(DEAD_ANIM, true);
        anim.SetBool(ATTACKED_ANIM, false);
        enemyDead = true;
        StartCoroutine(deadEffectSpawner());
        AttackPoint.SetActive(false);
        audi.PlayOneShot(enemyDeadSound);
        Debug.LogError("enemy died");
    }

    void StopDeadAnim()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Death"))
        {
            anim.SetBool(DEAD_ANIM, false);
        }
    }

    public void EnemyTakeDamage(float amount)
    {
        realHealth -= amount;
Debug.LogError("enemy: "+realHealth);
        if (realHealth <= 0)
        {
            realHealth = 0;
            EnemyDying();
        }

        if (amount > 0)
        {
            enemyHit = true;
        }
        Debug.Log(realHealth);
    }

    void EnemyAttacked()
    {
        enemyHit = false;
        anim.SetBool(ATTACKED_ANIM, true);
        anim.SetBool(ATTACK_ANIM, false);
        transform.Translate(Vector3.back * 0.5f);
    }

    void StopEnemyHit()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Damage"))
        {
            anim.SetBool(ATTACKED_ANIM, false);
        }
    }

    IEnumerator deadEffectSpawner()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(deadEffect, deadEffectPoint.position, deadEffectPoint.rotation);
        Destroy(gameObject);
    }
}
