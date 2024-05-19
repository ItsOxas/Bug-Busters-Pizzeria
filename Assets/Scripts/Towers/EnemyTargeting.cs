using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargeting : MonoBehaviour
{
    public string tag;
    public float range;
    public Transform target;
    void Start()
    {
        
    }


    void Update()
    {
        if (target == null)
        {
            FindTareget();
        }
        else
        {
            UpdateTarget();
        }


    }


    private async void FindTareget()
    {
        GameObject[] bugs = GameObject.FindGameObjectsWithTag(tag);
        await new WaitForSeconds(0.01f);
        foreach (GameObject bug in bugs)
        {
            float condidateDistance = Vector2.Distance(transform.position, bug.transform.position);
            if (condidateDistance < range)
            {
                target = bug.transform;  
            }
        }

    }

    private async void UpdateTarget()
    {
        GameObject[] bugs = GameObject.FindGameObjectsWithTag(tag);
        await new WaitForSeconds(0.01f);
        foreach (GameObject bug in bugs)
        {
            float condidateDistance = Vector2.Distance(transform.position, bug.transform.position);
            if (condidateDistance < range)
            {
                if (Vector2.Distance(transform.position, target.position) > condidateDistance)
                {
                    target = bug.transform;
                }
            }
        }
        if(Vector2.Distance(transform.position, target.position) > range)
        {
            target = null;
        }
    }
}
