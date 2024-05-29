using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Bug : MonoBehaviour
{ 
    public float speed;

    public float startHealth = 100;
    private float health;

    void Start()
    {
        health = startHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }
    public void Die() 
    {
        Spawner.enemiesLeft--;

        if (health == 0)
        {
            Destroy(gameObject);
        }

    }


}
