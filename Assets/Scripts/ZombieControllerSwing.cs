using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieContollerSwing : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private Animator anim = null;
    private float timeOfLastAttack = 0;
    private EnemyStats stats = null;
    private bool isStopped = false;
    private bool playerNear = false;
    [SerializeField] Transform target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        stats = GetComponent<EnemyStats>();
    }
    void Update()
    {
        //Debug.Log(playerNear);
        if (playerNear)
            MoveToTarget();
        if (gameObject.CompareTag("DayLightRoomZombie"))
        {
            if ((target.position.x < 16) || (target.position.x > 28) || (target.position.z > -15) || (target.position.z < -30))
            {
                playerNear = false;
                anim.SetBool("playerNear", false);

            }
            else
            {
                playerNear = true;
            }
        }
        else if (gameObject.CompareTag("DiningRoomZombie"))
        {
            if ((target.position.x < -27) || (target.position.x > -16) || (target.position.z > -15) || (target.position.z < -31))
            {
                playerNear = false;
                anim.SetBool("playerNear", false);

            }
            else
            {
                playerNear = true;
            }
        }
        else if (gameObject.CompareTag("OfficeZombie"))
        {
            if ((target.position.x < 0.5) || (target.position.x > 8) || (target.position.z > 13.5) || (target.position.z < 8.3))
            {
                playerNear = false;
                anim.SetBool("playerNear", false);

            }
            else
            {
                playerNear = true;
            }
        }
        else if (gameObject.CompareTag("VisitRoomZombie"))
        {
            if ((target.position.x < 7) || (target.position.x > 15) || (target.position.z > -7) || (target.position.z < -13))
            {
                playerNear = false;
                anim.SetBool("playerNear", false);

            }
            else
            {
                playerNear = true;
            }
        }

    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
        anim.SetBool("playerNear", true);
        anim.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
        //RotateToTarget();
        float distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget <= agent.stoppingDistance)
        {
            anim.SetFloat("Speed", 0f, 0.0f, Time.deltaTime);
            if (!isStopped)
            {
                isStopped = true;
                timeOfLastAttack = Time.time;
            }
            //Attack
            if (Time.time >= timeOfLastAttack + stats.attackSpeed)
            {
                timeOfLastAttack = Time.time;
                PlayerStats playerStats = target.GetComponent<PlayerStats>();
                AttackTarget(playerStats);
            }
        }
        else
        {
            if (isStopped)
            {
                isStopped = false;
            }
        }
    }

    private void RotateToTarget()
    {
        // transform.LookAt(target);
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }

    private void AttackTarget(PlayerStats playerStats)
    {
        if (!playerStats.isDead)
        {
            anim.SetTrigger("Attack");
            stats.DealDamage(playerStats);
        }
    }
}
