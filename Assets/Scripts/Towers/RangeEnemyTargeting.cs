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
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tag))
        {
            if (target == null)
            {
                target = collision.gameObject.transform;
                return;
            }
            float condidateDistance = Vector2.Distance(transform.position, collision.gameObject.transform.position);
            if(Vector2.Distance(transform.position, target.position) > condidateDistance)
            {
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
