using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBossCollision : MonoBehaviour
{
    public LayerMask bossLayer;
    public float radius;
    private bool iscollided;

    public GameObject hitPoint;
    
    public float damageCount;
    public Transform bossDamageEffect;
    private BossHealth bossHealth;

    


    private void Update()
    {
        Collider[] Hits = Physics.OverlapSphere(transform.position, radius, bossLayer);

        foreach (Collider c in Hits)
        {
            if(c.isTrigger)
            {
                continue;
            }
            iscollided = true;
            bossHealth = c.gameObject.GetComponent<BossHealth>();
            if (iscollided)
            {
                Instantiate(bossDamageEffect, hitPoint.transform.position, hitPoint.transform.rotation);
                bossHealth.BossDamage(damageCount);
                 
                iscollided = false;
            }
        }

        
    }
}
