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

    public float chaseSpeed, walkSpeed;

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
            transform.LookAt(Player);
            if(distance > 4f)
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

                

            }
        }

        if (enemyHealth.realHealth <= 0)
        {
            col.enabled = false;
        }

        if (playerHealth.realHealth <= 0)
        {
            // EnemyVictory()
        }

        if (victory)
        {
            //EnemyIsVıctory()
        }
    }

    void Search()
    {
        if(navAgent.remainingDistance <= 0.5f)
        {
            
            
            anim.SetBool(AnimationStates.ENEMY_ATTACK, false);

            if (navIndex == navpoints.Length - 1) navIndex = 0;
            else navIndex++;

            navAgent.SetDestination(navpoints[navIndex].position);
            anim.SetBool(AnimationStates.ENEMY_RUN, true);

            rb.AddForce((navAgent.destination - transform.position) * chaseSpeed * Time.deltaTime, ForceMode.Acceleration);
            transform.LookAt((navAgent.destination));
        }
        else
        {
            
            anim.SetBool(AnimationStates.ENEMY_RUN, true);

            rb.AddForce((navAgent.destination - transform.position) * chaseSpeed* Time.deltaTime, ForceMode.Acceleration );
            transform.LookAt((navAgent.destination));

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
       anim.SetBool(AnimationStates.ENEMY_RUN, true);
        rb.AddForce((Player.transform.position - transform.position) * chaseSpeed, ForceMode.Acceleration );
    }

    void Walk()
    {
        anim.SetBool(AnimationStates.ENEMY_RUN, true);
        transform.position = transform.position + new Vector3(Random.Range(-2f, 2f), 0f, Random.Range(-2f, 2f));
        // rb.AddForce(new Vector3(Random.Range(-2f, 2f), 0f, Random.Range(-2f, 2f)) * walkSpeed );

    }
    void EnemyVictory()
    {
        victory = true;
       // anim.SetBool(); victory animation bulunca burda aktif et
    }

    void EnemyVictoryFinish()
    {
        // anim.GetCurrentAnimatorStateInfo(0).IsName(victory) = false
    }
}
