using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    static public int money;

    void Start()
    {
        money = 0;
    }

    static void Buy(int value)
    {
        if (money >= value)
        {
            money -= value;
            return;
        }

    }
}
