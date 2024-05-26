using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Customers : MonoBehaviour
{
    public GameObject exit;

    public GameObject orderBubble;
    
    public GameObject target;
    NavMeshAgent agent;
    public bool isSiting = false;

    public Event onInteraction;


    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;        
        SpawnCustomers.availableSeats.Remove(target);
    }
    public void Update()
    {
        if (isSiting)
        {

        }
        else 
        {
            Enter();
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
            isSiting = true;
            Invoke("Order", Random.Range(3f, 8f));
        }
    }
    private void Enter()
    {
       agent.SetDestination(target.transform.position);
    }

   private void Exit()
    {
        target = exit;

        agent.SetDestination(target.transform.position);


    }

    void Order()
    {
        orderBubble.SetActive(true);
    }
}

