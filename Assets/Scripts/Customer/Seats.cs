using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seats : MonoBehaviour
{
    static public List<GameObject> seat;

    static private void Awake()
    {
        seat = new List<GameObject>(GameObject.FindGameObjectsWithTag("Chair"));
    }
}
