using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCollision : MonoBehaviour
{
    public LayerMask playerLayer;
    public float radius;
    private bool iscollided;

    public Transform hitPoint;
    public float damageCount;

    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        
    }


    private void Update()
    {
        Collider[] Hits = Physics.OverlapSphere(hitPoint.position, radius, playerLayer);

        foreach (Collider c in Hits)
        {
            if(c.isTrigger)
            {
                continue;
            }
            // çok fazla hasar verio onu düzelticez çok çalışıyo
            iscollided = true;
            if (iscollided)
            {
                playerHealth.TakeDamage(damageCount);
                iscollided = false;
            }
        }

        
    }
}
