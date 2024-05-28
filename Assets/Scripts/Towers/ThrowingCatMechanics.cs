using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingCatMechanics : MonoBehaviour
{
    public RangeEnemyTargeting ret;
    public Transform target;

    public int damage = 1;

    public float coolDownDuration = 1f;
    public bool coolingDown = false;

    public GameObject ballPrefab;

    public GameObject TowerPrefab;
    public GameObject tower;

    void Start()
    {
        tower = Instantiate(TowerPrefab, transform.position + new Vector3(-0.3f, 1.7f, 0), Quaternion.identity);
        ret = GetComponent<RangeEnemyTargeting>();
    }


    void Update()
    {
        if (ret.target != null)
        {
            CatAwake();
        }
        else
        {
            CatSleep();
        }
    }

    public void CatAwake()
    {
        target = ret.target;

        if (!coolingDown)
        {
            Throw();
        }
    }

    public void CatSleep()
    {
        target = null;
    }
    public void Throw()
    {
        coolingDown = true;
        var obj = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        obj.GetComponent<BallMechanics>().target = target;
        obj.GetComponent<BallMechanics>().damage = damage;
        ResetCoolDown();

    }
    public async void ResetCoolDown()
    {
        await new WaitForSeconds(coolDownDuration);
        coolingDown = false;
    }



}
