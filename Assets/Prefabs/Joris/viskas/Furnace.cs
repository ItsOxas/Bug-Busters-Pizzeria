using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Furnace : MonoBehaviour
{

    public float TimeToMakePizza = 5.0f;
    public bool makepizza = false;
    public List<GameObject> Picos;
    public int KuriPica;
    public GameObject AllButtons;
    public Slider Slider;
    public GameObject PizzaSpawnPoint;

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
                Slider.value = TimeToMakePizza;
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
        Slider.maxValue = TimeToMakePizza;
    }
    public void PizzaReady()
    {
        print("hello");
        Instantiate(Picos[KuriPica], SpawnPoint.transform.position, Quaternion.identity);
        
    }
}
