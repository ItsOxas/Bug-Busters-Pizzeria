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
        if (target != null)
        {
            agent.SetDestination(target.transform.position);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}

