using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
<<<<<<<< HEAD:Assets/Prefabs/Joris/ViskasJ/Furnace.cs
<<<<<<< Updated upstream
using UnityEngine.UI;
=======
using UnityEngine.UIElements;
>>>>>>> Stashed changes
========
using UnityEngine.UI;
>>>>>>>> main:Assets/Prefabs/Joris/viskas/Furnace.cs

public class Furnace : MonoBehaviour
{

    public float TimeToMakePizza = 5.0f;
    public bool makepizza = false;
    public List<GameObject> Picos;
    public int KuriPica;
    public GameObject AllButtons;
<<<<<<<< HEAD:Assets/Prefabs/Joris/ViskasJ/Furnace.cs
<<<<<<< Updated upstream
    public GameObject SpawnPoint;
    public Slider Slider;
=======
    public GameObject PizzaSpawnPoint;
    public Slider slider;
>>>>>>> Stashed changes

========
    public Slider Slider;
    public GameObject PizzaSpawnPoint;
>>>>>>>> main:Assets/Prefabs/Joris/viskas/Furnace.cs

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
<<<<<<< Updated upstream
                
=======
                slider.value = TimeToMakePizza;
>>>>>>> Stashed changes
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
<<<<<<<< HEAD:Assets/Prefabs/Joris/ViskasJ/Furnace.cs
<<<<<<< Updated upstream
        Slider.maxValue = TimeToMakePizza;
=======
        
>>>>>>> Stashed changes
========
        Slider.maxValue = TimeToMakePizza;
>>>>>>>> main:Assets/Prefabs/Joris/viskas/Furnace.cs
    }
    public void PizzaReady()
    {
        print("hello");
<<<<<<<< HEAD:Assets/Prefabs/Joris/ViskasJ/Furnace.cs
        Instantiate(Picos[KuriPica], SpawnPoint.transform.position, Quaternion.identity);
========
        Instantiate(Picos[KuriPica], PizzaSpawnPoint.transform.position, Quaternion.identity);
>>>>>>>> main:Assets/Prefabs/Joris/viskas/Furnace.cs
        
    }
}
