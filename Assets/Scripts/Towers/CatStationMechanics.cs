using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CatStationMechanics : MonoBehaviour
{
    public Transform catParent;
    public string catType = "";
    public UpgradeMechanics upgradeManager;

    public int level = 1;

        
    void Start()
    {
        var towers = GameObject.FindGameObjectsWithTag("Tower");
        this.name = "Tower" + towers.Length;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            foreach (RaycastHit2D target in hit)
            {
                if (target.collider.gameObject.CompareTag("Tower"))
                {
                    if(target.collider.gameObject == this.gameObject)
                    {
                        upgradeManager.UpdatePanelEnable(this.gameObject);
                    }

                }
            }
        }
    }

    private void OnMouseDown()
    {
        //print(gameObject.name);
        //upgradeManager.UpdatePanelEnable(gameObject);
    }

    public void LevelUp()
    {
        this.level++;
        this.upgradeManager.UpdateButton();
        switch (this.catType)
        {
            case var value when value == "SleepyCat":
                this.catParent.GetComponent<SleepyCatMechanics>().LevelUp();
                break;
            case var value when value == "ThrowingCat":
                this.catParent.GetComponent<ThrowingCatMechanics>().LevelUp();
                break;
            case var value when value == "WalkingCat":
                this.catParent.GetComponent<WalkingCatMechanics>().LevelUp();
                break;
        }
    }
}
