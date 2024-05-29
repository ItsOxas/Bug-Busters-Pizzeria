using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using UnityEngine;
using UnityEngine.Events;


public class Interactions : MonoBehaviour
{
    public bool triggerActive = false;

    // cia pridekit jei reikia daugiau interiactions ir pridekit jam tag interactable
    public UnityEvent Furnace;
    public UnityEvent CarryingPizza;
    public UnityEvent CustomerGetingPizza;

    [SerializeField]public Collider2D col;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "interactable")
        {
            triggerActive = true;
        }
        col = collision;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "interactable")
        {
            triggerActive = false;
        }
        col = null;
    }

    void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.E))
        {
            // cia unity eventa invokinkite ir parasykite pavadinima objecto
            if (col.gameObject.layer == 29)
            {
                Furnace.Invoke();
            }
            else if (col.gameObject.layer == 30)
            {
                CarryingPizza.Invoke();
            }
            else if (col.gameObject.layer == 31)
            {
                CustomerGetingPizza.Invoke();
            }
            print(":)");
        }
    }


}
