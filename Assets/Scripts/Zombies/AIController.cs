using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public GameObject target;
    public NavMeshAgent agent;
    private Animator anim = null;
    public float startWaitTime = 4;
    public float timeToRotate = 2;
    public float speedWalk = 6;
    public float speedRun = 9;
    public float viewRadius = 20;
    public float viewAngle = 360;
    public float meshResolution = 1f;
    public float edgeDistance = 0.5f;
    public int edgeIterations = 4;
    public LayerMask playerMask;
    public LayerMask obstacleMask;

    public GameObject[] waypoints;
    int m_CurrentWaypointIndex;
    Vector3 playerLastPostition = Vector3.zero;
    Vector3 m_PlayerPostition;
    float m_WaitTime;
    float m_TimeToRotate;
    bool m_PlayerInRange;
    bool m_PlayerNear;
    bool m_IsPatrol;
    bool m_CaughtPlayer;

    void Start()
    {
        m_PlayerPostition = Vector3.zero;
        m_IsPatrol = true;
        m_CaughtPlayer = false;
        m_PlayerInRange = false;
        m_WaitTime = startWaitTime;
        m_TimeToRotate = timeToRotate;
        m_CurrentWaypointIndex = 0;
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = false;
        agent.speed = speedWalk;
        agent.SetDestination(waypoints[m_CurrentWaypointIndex].transform.position);
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        EnvironmentView();
        if (!m_IsPatrol)
        {
            Chasing();
        }
        else
        {
            Patroling();
        }
    }


    private void Chasing()
    {
        m_PlayerNear = false;
        playerLastPostition = Vector3.zero;
        if (!m_CaughtPlayer)
        {
            Move(speedRun);
            agent.SetDestination(m_PlayerPostition);
        }
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            CaughtPlayer();
            if (m_WaitTime <=0 && !m_CaughtPlayer && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 6f)
            {
                m_IsPatrol = true;
                m_PlayerNear = false;
                Move(speedWalk);
                m_TimeToRotate = timeToRotate;
                m_WaitTime = startWaitTime;
                agent.SetDestination(waypoints[m_CurrentWaypointIndex].transform.position);
            }
            else
            {
                if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 2.5f)
                {
                    Stop();
                    m_WaitTime -= Time.deltaTime;
                }
            }
        }
    }
    
    private void Patroling()
    {
        if (m_PlayerNear)
        {
            if (m_TimeToRotate <= 0)
            {
                Move(speedWalk);
                LookingForPlayer(playerLastPostition);
            }
            else
            {
                Stop();
                m_TimeToRotate -= Time.deltaTime;
            }
        }
        else
        {
            m_PlayerNear = false;
            playerLastPostition = Vector3.zero;
            agent.SetDestination(waypoints[m_CurrentWaypointIndex].transform.position);
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (m_WaitTime <= 0)
                {
                    NextPoint();
                    Move(speedWalk);
                    m_WaitTime = startWaitTime;
                }
                else
                {
                    Stop();
                    m_WaitTime -= Time.deltaTime; 
                }
            }
        }
    }
    void CaughtPlayer()
    {
        m_CaughtPlayer = true;
    }

    void Move(float speed)
    {
        agent.isStopped = false;
        agent.speed = speed;
        anim.SetFloat("Speed", 1f,0.3f,Time.deltaTime);
    }

    void Stop()
    {
        agent.isStopped = true;
        agent.speed = 0;
    }

    public void NextPoint()
    {
        if (agent.remainingDistance < 0.5f)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            agent.SetDestination(waypoints[m_CurrentWaypointIndex].transform.position);
        }
    }
    
    void LookingForPlayer(Vector3 player)
    {
        agent.SetDestination(player);
        if(Vector3.Distance(transform.position, player) <= 0.3)
        {
            if (m_WaitTime <= 0)
            {
                m_PlayerNear = false;
                Move(speedWalk);
                agent.SetDestination(waypoints[m_CurrentWaypointIndex].transform.position);
                m_WaitTime = startWaitTime;
                m_TimeToRotate = timeToRotate;
            }
            else
            {
                Stop();
                m_WaitTime -= Time.deltaTime;
            }
        }
    }

    void EnvironmentView()
    {
        Collider[] playerInRange = Physics.OverlapSphere(transform.position, viewRadius, playerMask);
        for(int i = 0; i< playerInRange.Length; i++)
        {
            Transform player = playerInRange[i].transform;
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, dirToPlayer) < viewAngle / 2)
            {
                float distToPlayer = Vector3.Distance(transform.position, player.position);
                if (!Physics.Raycast(transform.position, dirToPlayer, distToPlayer, obstacleMask))
                {
                    m_PlayerInRange = true;
                    m_IsPatrol = false;
                }
                else
                {
                    m_PlayerInRange = false;
                }
            }
            if (Vector3.Distance(transform.position, player.position) > viewRadius)
            {
                m_PlayerInRange = false;
            }
            if (m_PlayerInRange)
            {
                m_PlayerPostition = player.transform.position;
            }
        }
    }

}