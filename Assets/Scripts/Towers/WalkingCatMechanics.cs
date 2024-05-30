using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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

    public UpgradeMechanics upgradeManager;

    public int level = 1;

    public float[] modificators = { 0, 1.6f, 2.6f };

    public AudioClip catMeleeSound;

    void Start()
    {
        tower = Instantiate(TowerPrefab, transform.position + new Vector3(-0.3f, 1.7f, 0), Quaternion.identity);
        tower.GetComponent<CatStationMechanics>().upgradeManager = upgradeManager;
        tower.GetComponent<CatStationMechanics>().catParent = transform;
        tower.GetComponent<CatStationMechanics>().catType = "WalkingCat";
        var towers = GameObject.FindGameObjectsWithTag("Tower");


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
        AudioManager.Play(catMeleeSound, 1f);
        coolingDown = true;
        target.GetComponent<Bug>().TakeDamage(Mathf.RoundToInt(damage * modificators[level - 1]));
        ResetCoolDown();
    }

    public async void ResetCoolDown()
    {
        await new WaitForSeconds(coolDownDuration);
        coolingDown = false;
    }


    public void LevelUp()
    {
        this.level++;
        coolDownDuration /= modificators[level - 1];
        walkSpeed *= modificators[level - 1];
    }
}
