using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.Rendering.UI;
using UnityEngine.Tilemaps;
using UnityEngine.Windows;

public class Customers : MonoBehaviour
{
    public Animator anim;
    private bool moving;

    public GameObject exit;

    public GameObject orderBubble;
    
    public GameObject target;
    NavMeshAgent agent;
    bool isSiting = false;
    bool isEatting;

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
        Enter();

        Animate();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
            isSiting = true;     
            Invoke("Order", Random.Range(3f, 8f));
        }
        if (isEatting)
        {
            Eating();
        }

    }
    private void Enter()
    {
       agent.SetDestination(target.transform.position + new Vector3(0,0.5f,0));
    }

   private void Exit()
    {
        target = exit;

        agent.SetDestination(target.transform.position);

        isSiting = false;    
    }

    void Order()
    {
        orderBubble.SetActive(true);
        GettingPizza();
    }

    void GettingPizza()
    {
        isEatting = true;
        orderBubble.SetActive(false);
    }

    void Eating()
    {
            Invoke("Exit", 1);
    }

    void Animate()
    {
        if (agent.velocity.magnitude > 0.1f || agent.velocity.magnitude < -0.1f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        if (moving)
        {
            anim.SetFloat("X", agent.velocity.x);
            anim.SetFloat("Y", agent.velocity.y);
        }

        anim.SetBool("Moving", moving);
        if (isSiting)
        {
            anim.SetBool("isSitting", true);
            anim.SetFloat("X", agent.velocity.x);
            if (target.layer == 9)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }


}

