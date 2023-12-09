using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControlAgent : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField]
    Transform player;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 10, new Color(1, 0, 0));
        if(Physics.Raycast(transform.position,transform.forward,out hit,10))
        {
            if(hit.collider.CompareTag("Player"))
                agent.SetDestination(hit.point);
        }
        //agent.SetDestination(player.position);
    }
}
