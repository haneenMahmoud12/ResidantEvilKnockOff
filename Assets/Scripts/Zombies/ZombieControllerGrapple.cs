using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class ZombieContollerGrapple : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private Animator anim = null;
    private float timeOfLastAttack = 0;
    private EnemyStats stats = null;
    private bool isStopped = false;
    private bool playerNear = false;
    private PlayerStats playerStats;
    [SerializeField] Transform target;
    [SerializeField] Animator playerAnim;
    public InventoryScript inventoryScript;
    public GameObject player;
    private bool canGrapple = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        stats = GetComponent<EnemyStats>();
        stats.damage = 5;
        
       // target = GetComponent<Transform>();
        playerStats = target.GetComponent<PlayerStats>();
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
            if ((target.position.x < -16) || (target.position.x > -7) || (target.position.z > -7) || (target.position.z < -13))
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

    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
        stats.ZombieRunning();
        anim.SetBool("playerNear", true);
        anim.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
        //RotateToTarget();
        float distanceToTarget = agent.remainingDistance;
       // float distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget <= agent.stoppingDistance)
        {
            anim.SetFloat("Speed", 0f, 0.0f, Time.deltaTime);
            if (!isStopped)
            {
                isStopped = true;
                timeOfLastAttack = Time.time;
            }
            //Attack
            if (Time.time >= timeOfLastAttack + stats.attackSpeed+3)
            {
                timeOfLastAttack = Time.time;
                //Debug.Log("hi");
                if (canGrapple)
                {
                    AttackTarget(playerStats);
                    StartCoroutine(NotGrappled());
                }
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
        //agent.transform.forward = -target.position;
        transform.LookAt(target);
       /* Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;*/
    }

    private void AttackTarget(PlayerStats playerStats)
    {
        if (inventoryScript.leonHealthPoints !=0)
        {
            RotateToTarget();
            //anim.SetTrigger("Attack");
            anim.SetBool("Grapple",true);
            playerStats.isGrappled = true;
            playerAnim.SetBool("isGrappled", true);
            PlayerInput pi = player.GetComponent<PlayerInput>();
            pi.actions.FindAction("Sprint").Disable();
            pi.actions.FindAction("Move").Disable();
            pi.actions.FindAction("Aim").Disable();
            stats.damage = 5;
            //Debug.Log("AttackTarget");
            //stats.DealDamage(playerStats);
            //Debug.Log(stats.damage);
            //inventoryScript.DecreasePlayerHealth(5);
        }
    }
    private IEnumerator NotGrappled()
    {
       // Debug.Log("notGrappled");
        if (inventoryScript.brokeFormGrapple)
        {
            playerAnim.SetBool("stab", true);
            playerAnim.SetBool("isGrappled", false);
            canGrapple = false;
            inventoryScript.brokeFormGrapple = false; 
            anim.SetBool("Grapple", false);
            yield return new WaitForSeconds(4);
            canGrapple = true;
        }
        else
        {
            yield return new WaitForSeconds(4);
            playerStats.isGrappled = false;
            anim.SetBool("Grapple", false);
            playerAnim.SetBool("isGrappled", false);
            PlayerInput pi = player.GetComponent<PlayerInput>();
            pi.actions.FindAction("Sprint").Enable();
            pi.actions.FindAction("Move").Enable();
            pi.actions.FindAction("Aim").Enable();
            //Debug.Log("Here");
            playerAnim.SetTrigger("StabTrig");
            inventoryScript.DecreasePlayerHealth(5);
        }
    }
}
