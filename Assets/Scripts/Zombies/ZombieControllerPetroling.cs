using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieContollerPetroling : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private Animator anim = null;
    private float timeOfLastAttack = 0;
    private EnemyStats stats = null;
    private bool isStopped = false;
    private bool playerNear = false;
    [SerializeField] Transform target;
    [SerializeField] GameObject[] waypoints;
    int i=0;
    public InventoryScript inventoryScript;
    public AudioSource zombieIsPetroling;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        stats = GetComponent<EnemyStats>();
        
      //  GameObject gameObject = GetComponent<GameObject>();
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
            if ((target.position.x <-16) || (target.position.x > -7) || (target.position.z > -7) || (target.position.z < -13))
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

        if (stats.isDead)
        {
            if (stats.killZombie)
            {
                anim.SetTrigger("die");
                stats.killZombie = false;
                //Destroy(gameObject, 5);
            }
        }

        if (stats.isHit)
        {
            if (stats.isDead)
            {
                if (stats.killZombie)
                {
                    anim.SetTrigger("die");
                    stats.killZombie = false;
                }
            }
            else
            {
                anim.SetTrigger("HitReaction");
                stats.isHit = false;
            }

        }

        if (!playerNear && gameObject!=null)
        {
            zombieIsPetroling.Play();
            if (agent.remainingDistance < 1.5f)
            {
                i = (i + 1) % waypoints.Length;
                agent.SetDestination(waypoints[i].transform.position);
            }
        }

    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
        stats.ZombieRunning();
        anim.SetBool("playerNear", true);
        anim.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
        //RotateToTarget();
        //float distanceToTarget = Vector3.Distance(target.position, transform.position);
        float distanceToTarget = agent.remainingDistance;
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
        transform.LookAt(target);
        /*Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;*/
    }

    private void AttackTarget(PlayerStats playerStats)
    {
        if (inventoryScript.leonHealthPoints !=0)
        {
            RotateToTarget();
            anim.SetTrigger("Attack");
            stats.damage = 2;
            if (!playerStats.isGrappled)
                StartCoroutine(DelayDamage());
            //stats.DealDamage(playerStats);
            //inventoryScript.DecreasePlayerHealth(2);
            //stats.DealDamage(playerStats);
        }
    }

    private IEnumerator DelayDamage()
    {
        yield return new WaitForSeconds(2f);
        inventoryScript.DecreasePlayerHealth(2);
    }
}
