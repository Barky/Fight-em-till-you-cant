using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoveStart : MonoBehaviour
{
    private CapsuleCollider col;
    private BossAI bossai;

    private void Awake()
    {
        col = GetComponent<CapsuleCollider>();
        bossai = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossAI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            bossai.enabled = true;
            col.enabled = false;
        }
    }
}
