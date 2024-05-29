using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Furnace : MonoBehaviour
{
    bool inRange = false;

    public GameObject pizzaPrefab;

    void Start()
    {

    }

    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject pizza = Instantiate(pizzaPrefab, transform);
                pizza.GetComponent<Rigidbody2D>().AddForce(transform.up * 2);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
    }
}

