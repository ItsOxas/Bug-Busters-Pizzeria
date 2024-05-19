using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Bug : MonoBehaviour
{ 
    public float startSpeed = 10f;

    public float speed;

    public float startHealth = 100;
    private float health;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

    }

}
