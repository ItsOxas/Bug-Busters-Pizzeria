using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public float speed;
    float speedX;
    float speedY;
    Vector2 input;
    


    public Animator anim;
    private bool moving;


    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal");
        speedY = Input.GetAxisRaw("Vertical");

        input = new Vector2(speedX, speedY); 
        input.Normalize();

        Animate();
    }
    private void FixedUpdate()
    {
        rb.velocity = input * speed;
    }

    void Animate()
    {
        if (input.magnitude > 0.1f || input.magnitude < -0.1f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        if (moving)
        {
            anim.SetFloat("X",speedX);
            anim.SetFloat("Y", speedY);
        }

        anim.SetBool("Moving", moving);
    }
}
