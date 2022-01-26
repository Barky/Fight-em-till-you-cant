using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    private Transform Enemy;
    private Transform Player;

    private CapsuleCollider col;
    private Animator anim;

    public float chaseSpeed;

    private EnemyHealth enemyHealth;
    private PlayerHealth playerHealth;
    private bool victory;
}
