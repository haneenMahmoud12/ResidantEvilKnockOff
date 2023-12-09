using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // MUST IMPORT THE AI PACKAGE I INSTALLED 
public class FollowTarget : MonoBehaviour
{
    //public to access from inspector and must reference (drag drop target)
    public GameObject target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);
    }
}
