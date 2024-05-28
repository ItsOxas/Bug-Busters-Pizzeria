using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingCatMechanics : MonoBehaviour
{
    public RangeEnemyTargeting ret;
    public Transform target;

    public int damage = 1;
    public float walkSpeed = 1f;

    public float coolDownDuration = 1f;
    public bool coolingDown = false;

    public float distanceToTarget;

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

        distanceToTarget = Vector2.Distance(transform.position, target.transform.position);


        print(distanceToTarget);
        if (!coolingDown && distanceToTarget < 3)
        {
            Attack();
        }
        else if(distanceToTarget >= 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, walkSpeed * Time.deltaTime);
        }
    }
    public void CatSleep()
    {
        target = null;
        transform.position = Vector2.MoveTowards(transform.position, tower.transform.position - new Vector3(-0.3f, 1.7f, 0), (walkSpeed * Time.deltaTime) * 0.8f);
    }

    public void Attack()
    {
        coolingDown = true;
        target.GetComponent<Bug>().TakeDamage(damage);
        ResetCoolDown();
    }

    public async void ResetCoolDown()
    {
        await new WaitForSeconds(coolDownDuration);
        coolingDown = false;
    }

}
