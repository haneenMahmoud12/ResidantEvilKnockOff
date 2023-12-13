using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieThrow : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private Animator anim = null;
    //private float timeOfLastAttack = 0;
    private EnemyStats stats = null;
    private bool isStopped = false;
    private bool playerNear = false;
    [SerializeField] Transform target;
    //private bool killZombie = false;
    public float throwForce = 70f;
    public float throwUpwardForce=4f;
    public Transform bladeArea;
    public Transform launchPoint;
    public GameObject bladePrefab;

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
               // Destroy(gameObject, 5);
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
        PlayerStats playerStats = target.GetComponent<PlayerStats>();
        //RotateToTarget();
        anim.SetBool("playerNear", true);
        if(!isStopped)
            AttackTarget(playerStats);
    }

    private void RotateToTarget()
    {
        transform.LookAt(target);
       /* Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;*/
    }

    private void AttackTarget(PlayerStats playerStats)
    {
        if (!playerStats.isDead)
        {
            //agent.transform.forward = target.position;
            RotateToTarget();
            anim.SetTrigger("Attack");
            StartCoroutine(ThrowBlade());
            stats.damage = 3;
            if (!playerStats.isGrappled)
                stats.DealDamage(playerStats);
            isStopped = true;
        }
    }

    private IEnumerator ThrowBlade()
    {
        yield return new WaitForSeconds(1f);
        //GameObject blade = Instantiate(bladePrefab, agent.transform, true);
        GameObject blade = Instantiate(bladePrefab, launchPoint.position,agent.transform.rotation);
        //GameObject blade = Instantiate(bladePrefab, bladeArea.transform.position, bladeArea.transform.rotation);
        Rigidbody rb = blade.GetComponent<Rigidbody>();
        //rb.velocity = throwForce*launchPoint.up;
        //rb.AddForce(blade.transform.forward);
        Vector3 forceToAdd = agent.transform.forward * throwForce + transform.up * throwUpwardForce;

        rb.AddForce(forceToAdd,ForceMode.Impulse);
        
    }
}
