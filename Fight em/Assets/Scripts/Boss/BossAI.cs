using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    private Animator anim;
    private Transform player;
    private PlayerHealth playerHealth;
    private BossHealth bossHealth;

    public float walkDistance = 8f, skill1Distance = 5f, skill2Distance = 4f, skill3Distance = 2.5f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.gameObject.GetComponent<PlayerHealth>();
        bossHealth = GetComponent<BossHealth>();
    }


    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (bossHealth.realHealth > 0)
        {
            transform.LookAt(player);
        }

        if (playerHealth.realHealth <= 0)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Skill1", false);
            anim.SetBool("Skill2", false);
            anim.SetBool("Skill3", false);
            
        }

        if (playerHealth.realHealth > 0)
        {
            if (distance > walkDistance)
            {
                anim.SetBool("Walk", true);
                anim.SetBool("Skill1", false);
                anim.SetBool("Skill2", false);
                anim.SetBool("Skill3", false);
            }
            else
            {
                anim.SetBool("Walk", false);

                if (distance > skill1Distance)
                {
                    anim.SetBool("Skill1", true);
                    anim.SetBool("Skill2", false);
                    anim.SetBool("Skill3", false);
                }

                if (distance <= skill2Distance && distance > skill3Distance)
                {
                    anim.SetBool("Skill1", false);
                    anim.SetBool("Skill2", true);
                    anim.SetBool("Skill3", false);

                }

                if (distance <= skill3Distance)
                {
                    anim.SetBool("Skill1", false);
                    anim.SetBool("Skill2", false);
                    anim.SetBool("Skill3", true);

                }
            }
        }
    }
}
