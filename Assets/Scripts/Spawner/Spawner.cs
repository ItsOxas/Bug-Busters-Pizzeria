using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EnemySettings
{
    public int howMany;
    public int Distance;
    [Range(0, 4)] public float spawnInterval = 4f;
}

[System.Serializable]
public class EnemyPack
{
    public int enemyType;

    public List<EnemySettings> enemySettings;
}

[System.Serializable]
public class Wave
{
    public List<EnemyPack> enemies;
}

public class Spawner : MonoBehaviour
{
    public List<GameObject> enemiesType;
    public List<Transform> spawnPoints;
    public List<int> enemyCounts;

    public int currentWave;
    public List<Wave> waves;
    public List<EnemyPack> enemies;

    [Range(0, 10)] public float waveInterval = 10f;

    public int enemiesLeft;
    
    async void Start()
    {
        while (currentWave < waves.Count)
        {
            var wave = waves[currentWave];
            for (int i = 0; i < wave.enemies.Count; i++)
            {
                var enemy = wave.enemies[i];
                Spawn(enemy.enemyType);
            }

            await new WaitForSeconds(3f);
            currentWave++;
        }

        void Spawn(int enemyType)
        {
            var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            Instantiate(enemiesType[enemyType], spawnPoint.position, Quaternion.identity);
        }

    }
}
