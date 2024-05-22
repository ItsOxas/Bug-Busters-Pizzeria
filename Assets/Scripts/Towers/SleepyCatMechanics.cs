using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepyCatMechanics : MonoBehaviour
{

    public float TimeToMakePizza = 5.0f;
    public bool makepizza = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (makepizza)
        {
            if (TimeToMakePizza > 0.0f)
            {
                TimeToMakePizza -= Time.deltaTime;
            }
            else if (TimeToMakePizza < 0.0f)
            {
                PizzaReady();
                makepizza = false;
            }
        }
    }

    public void MakingPizza()
    {
        makepizza = true;
    }
    public void PizzaReady()
    {
        print("hello");
    }
}
