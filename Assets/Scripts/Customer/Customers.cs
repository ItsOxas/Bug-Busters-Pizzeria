using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Customers : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;


    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;    
    }
    public void Update()
    {
        agent.SetDestination(target.transform.position);
    }
}

