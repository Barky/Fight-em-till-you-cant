using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkillDamage : MonoBehaviour
{
    public LayerMask playerLayer;
    public float radius;
    private bool iscollided;

    
    public float damageCount;

    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        
    }


    private void Update()
    {
        Collider[] Hits = Physics.OverlapSphere(transform.position, radius, playerLayer);

        foreach (Collider c in Hits)
        {
            if(c.isTrigger)
            {
                continue;
            }
            iscollided = true;
            if (iscollided)
            {
                playerHealth.TakeDamage(damageCount);
                gameObject.SetActive(false);

            }
        }

        
    }
}
