using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallMechanics : MonoBehaviour
{

    public int damage = 1;

    public Transform target;

    public float trackStrength = 0.1f;

    public string enemyTag;

    void Start()
    {
        
    }


    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, target.position, trackStrength);

        if(target == null)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            target.GetComponent<Bug>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
