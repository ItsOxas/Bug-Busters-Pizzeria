using System.IO;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Brains : MonoBehaviour
{
    public float bugSpeed;

    public Transform target;
    float distance;
    Path path;

    private void Start()
    {
        path = FindObjectOfType<Path>();
        target = path.GetClosestPoint(transform.position);
    }

    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget < 3)
        {
            target = path.GetNextPoint(transform.position);
        }

        MoveTowards();
    }
    void MoveTowards() 
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, bugSpeed * Time.deltaTime);
        Vector2 pos = target.transform.position - transform.position;
        float angle = Mathf.Atan2(pos.x, pos.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
}