using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEvent : MonoBehaviour
{
    public GameObject AttackPoint;
    public GameObject attackEffect;

    void Enemyattack(bool attacking)
    {
        Debug.LogError("calisti anim");
        if (attacking)
        {
            Instantiate(attackEffect, AttackPoint.transform.position, AttackPoint.transform.rotation);
        }
    }

    void EnemyAttackStart(bool attackstarted)
    {
        if(attackstarted)
        {
            AttackPoint.SetActive(true);
        }
    }
    void EnemyAttackEnd(bool attackended)
    {
        if(attackended)
        {
            AttackPoint.SetActive(false);
        }
    }
}
