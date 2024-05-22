using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    bool inRange = false;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("Mama mia");
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
