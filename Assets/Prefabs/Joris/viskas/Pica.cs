using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pica : MonoBehaviour
{
    public int WitchPica;
    public int TimeForPicaToMake;
    public int MoneyEarnFromPica;
    GameObject player;

    public void CarryingPizza()
    {
        Destroy(gameObject);
    }
}
