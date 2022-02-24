using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
    public LayerMask enemyLayer;
    public float radius;
    private bool iscollided;

    public Transform hitPoint;
    public float damageCount;
    public GameObject attackEffect;

    private EnemyHealth enemyHealth;

    private void Awake()
    {
        if (!GameObject.FindGameObjectWithTag("Enemy")) return;
        enemyHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();
        
    }


    private void Update()
    {
        if (!enemyHealth) return;
        Collider[] Hits = Physics.OverlapSphere(hitPoint.position, radius, enemyLayer);

        foreach (Collider c in Hits)
        {
            if (c.isTrigger)
            {
                continue;
            }

            iscollided = true;
            if (iscollided)
            {
                enemyHealth.EnemyTakeDamage(damageCount);
                Instantiate(attackEffect, hitPoint.position, hitPoint.rotation);
                hitPoint.gameObject.SetActive(false);

            }
            
        }

        
    }
}
