using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public List<GameObject> enemyType;
    public List<Transform> spawnPoints;
    public List<int> enemyCounts;

    [Range(0.1f, 5)] public float spawnInterval = 1f;
    [Range(0, 10)] public float waveInterval = 10f;

    public int enemiesLeft;

    async void Start()
    {
        foreach (var count in enemyCounts)
        {
            enemiesLeft = count;
            while (enemiesLeft > 0)
            {
                Spawn();
                enemiesLeft--;
            }
        }
    }

    public void Spawn()
    {
        var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        Instantiate(enemyType[0], spawnPoint.position, Quaternion.identity);
    }
}
