using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyTargeting : MonoBehaviour
{
    public string tag;
    public Transform target;

    void Start()
    {
        
    }

    void Update()
    {
        print(target);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        print(1);
        if (collision.gameObject.CompareTag(tag))
        {
            print(2);
            if (target == null)
            {
                print(3);
                target = collision.gameObject.transform;
                return;
            }
            print(4);
            float condidateDistance = Vector2.Distance(transform.position, collision.gameObject.transform.position);
            if(Vector2.Distance(transform.position, target.position) > condidateDistance)
            {
                print(5);
                target = collision.gameObject.transform;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.transform == target)
        {
            target = null;
        }
    }
}
