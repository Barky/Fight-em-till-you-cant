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
            if (distance > 8f)
            {
                anim.SetBool("Walk", true);
                anim.SetBool("Skill1", false);
                anim.SetBool("Skill2", false);
                anim.SetBool("Skill3", false);
            }
            else
            {
                anim.SetBool("Walk", false);

                if (distance > 5.5f)
                {
                    anim.SetBool("Skill1", true);
                    anim.SetBool("Skill2", false);
                    anim.SetBool("Skill3", false);
                    Debug.LogError("skill 1 calisti");
                }

                if (distance <= 4f && distance > 2.5f)
                {
                    anim.SetBool("Skill1", false);
                    anim.SetBool("Skill2", true);
                    anim.SetBool("Skill3", false);
                    Debug.LogError("skill 2 calisti");

                }

                if (distance <= 2.5f)
                {
                    anim.SetBool("Skill1", false);
                    anim.SetBool("Skill2", false);
                    anim.SetBool("Skill3", true);
                    Debug.LogError("skill 3 calisti");

                }
            }
        }
    }
}
