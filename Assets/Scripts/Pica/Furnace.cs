using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Furnace : MonoBehaviour
{

    public float TimeToMakePizza = 5.0f;
    public bool makepizza = false;
    public List<GameObject> Picos;
    public int KuriPica;
    public GameObject AllButtons;
    public GameObject SpawnPoint;


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

    public void ChosingPizza()
    {
        AllButtons.SetActive(true);
    }

    public void MakingPizza()
    {
        KuriPica = gameObject.GetComponent<PicosButtons>().KuriPica;
        makepizza = true;
        TimeToMakePizza = Picos[KuriPica].GetComponent<Pica>().TimeForPicaToMake;
        AllButtons.SetActive(false);
    }
    public void PizzaReady()
    {
        print("hello");
        Instantiate(Picos[KuriPica], SpawnPoint.transform.position, Quaternion.identity);
        
    }
}
