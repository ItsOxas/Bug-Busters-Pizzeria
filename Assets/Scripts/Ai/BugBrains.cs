using UnityEngine;
using System.Collections;

public class BugBrains : MonoBehaviour
{

    private Transform target;
    private int wavepointIndex = 0;
    private Bug bug;

    void Start()
    {
        bug = GetComponent<Bug>();

        target = Path.points[0];
    }

    void Update()
    {
        Vector2 dir = target.position;
        MoveTowards(dir);

        if (Vector2.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Path.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Path.points[wavepointIndex];
    }

    void EndPath()
    {
        Invoke("Destroy", 4f);
        RestauranHealth.restauranHealth--;
    }
void MoveTowards(Vector2 direction) 
    {
        transform.position = Vector2.MoveTowards(transform.position, direction, bug.speed * Time.deltaTime);
        Vector2 pos = direction - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(pos.x, pos.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}