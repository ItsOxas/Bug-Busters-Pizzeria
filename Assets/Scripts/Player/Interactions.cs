using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Interactions : MonoBehaviour
{
    public bool triggerActive = false;
    public UnityEvent iteraction;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "furnace")
        {
            triggerActive = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "furnace")
        {
            triggerActive = false;
        }
    }

    void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.E))
        {
            iteraction.Invoke();
            print(":)");
        }
    }


}
