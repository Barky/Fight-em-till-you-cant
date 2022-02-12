using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
    private Transform Enemy;
    private Transform Player;

    private CapsuleCollider col;
    private Animator anim;

    public float chaseSpeed, multiplier;

    private NavMeshAgent navAgent;
    public Transform[] navpoints;
    private int navIndex;

    Rigidbody rb;


    private EnemyHealth enemyHealth;
    private PlayerHealth playerHealth;
    private bool victory;

    private void Awake()
    {
        col = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        Enemy = this.transform;

        enemyHealth = this.GetComponent<EnemyHealth>();
        playerHealth = Player.gameObject.GetComponent<PlayerHealth>();

        navAgent = GetComponent<NavMeshAgent>();
        navIndex = Random.Range(0, navpoints.Length);
        navAgent.SetDestination(navpoints[navIndex].position);
    }

    private void Update()
    {
        float distance = Vector3.Distance(Enemy.position, Player.position);
        

        if(enemyHealth.realHealth > 0)
        {
            if(distance > 7f)
            {
                 Search();

                navAgent.isStopped = false;
            }
            else
            {
                navAgent.isStopped = true;

                if (distance > 2.5f)
                {
                    Chase();
                }
                else
                {
                    Attack();
                }

                transform.LookAt(Player);

            }
        }

    }

    void Search()
    {
        if(navAgent.remainingDistance <= 0.5f)
        {
            anim.SetBool(AnimationStates.ENEMY_RUN, false);
            anim.SetFloat(AnimationStates.ENEMY_SPEED, 0f);
            anim.SetBool(AnimationStates.ENEMY_ATTACK, false);

            if (navIndex == navpoints.Length - 1) navIndex = 0;
            else navIndex++;

            navAgent.SetDestination(navpoints[navIndex].position);
        }
        else
        {
            anim.SetBool(AnimationStates.ENEMY_RUN, false);
            anim.SetFloat(AnimationStates.ENEMY_SPEED, 1f);
            anim.SetBool(AnimationStates.ENEMY_ATTACK, false);
        }
    }

    void Chase()
    {
        Run();
        anim.SetFloat(AnimationStates.ENEMY_SPEED, chaseSpeed);
        anim.SetBool(AnimationStates.ENEMY_ATTACK, false);


    }

    void Attack()
    {
        anim.SetBool(AnimationStates.ENEMY_ATTACK, true);
    }

    void Run()
    {
        Debug.LogError("run calısıooo");
       anim.SetBool(AnimationStates.ENEMY_RUN, true);
        rb.AddForce((Player.transform.position - transform.position) * multiplier );
    }
}
