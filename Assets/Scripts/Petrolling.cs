using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Petrolling : MonoBehaviour
{
    int i = 0;
    public GameObject[] targets;
    NavMeshAgent agent;
    RaycastHit hit;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(targets[0].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 0.5f)
        {
         i=(i+1) % targets.Length;
            agent.SetDestination(targets[i].transform.position);
        }
    }
}
