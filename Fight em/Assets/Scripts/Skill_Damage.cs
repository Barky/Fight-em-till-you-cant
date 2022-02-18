using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Damage : MonoBehaviour
{
    public LayerMask enemyLayer;
    public float radius;
    private bool iscollided;

    
    public float damageCount;
    public GameObject attackEffect;

    private EnemyHealth enemyHealth;



    private void Update()
    {
        
        Collider[] Hits = Physics.OverlapSphere(transform.position, radius, enemyLayer);

        foreach (Collider c in Hits)
        {
            if (c.isTrigger)
            {
                continue;
            }
            enemyHealth = c.GetComponent<EnemyHealth>();
            iscollided = true;
            if (iscollided)
            {
                enemyHealth.EnemyTakeDamage(damageCount);
                Instantiate(attackEffect, transform.position, transform.rotation);
                iscollided = false;

            }
            
        }

        
    }
}
