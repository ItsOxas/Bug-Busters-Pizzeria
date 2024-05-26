using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCustomers : MonoBehaviour
{
    static public List<GameObject> seats;
    static public List<GameObject> availableSeats;

    public GameObject prefab;
    public Transform spawnPoint;

    bool spawn = true;

    static public int Customers;

    void Awake()
    {

        seats = new List<GameObject>(GameObject.FindGameObjectsWithTag("Chair"));
        availableSeats = new List<GameObject>(GameObject.FindGameObjectsWithTag("Chair"));

    }

    private void Update()
    {   
        if (spawn)
        {
            for (int x = 0; x < 1; x++)
            {             
                Invoke("Spawn", Random.Range(7f, 16f));
            }
            spawn = false;
        }
    }

    void Spawn()
    {
        GameObject customer = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

        customer.GetComponent<Customers>().target = availableSeats[Random.Range(0, availableSeats.Count)];            
        Customers++;
        
        spawn = true;
    }
}
