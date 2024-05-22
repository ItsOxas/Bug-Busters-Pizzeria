using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EnemyPack
{
    public int enemyType;
    public int amount;
    [Range(0, 80)] public float spawnTime;
    [Range(0, 4)] public float spawnInterval = 1f;

}

[System.Serializable]
public class Wave
{
    public List<EnemyPack> enemies;
    [Range(0, 80)] public float waveTime = 60f;
}

public class Spawner : MonoBehaviour
{
    public List<GameObject> enemiesType;
    public List<Transform> spawnPoints;

    public int currentWave;
    public List<Wave> waves;

    [Range(0, 10)] public float nextWaveInterval = 8f;

    static public int enemiesLeft;
    
    async void Start()
    {
        while (currentWave < waves.Count)
        {

            var wave = waves[currentWave];
            for (int i = 0; i < wave.enemies.Count; i++)
            {
                var enemy = wave.enemies[i];
                await new WaitForSeconds(enemy.spawnTime);
                for (int x = 0; x < enemy.amount; x++)
                {          
                    if(x != 0)await new WaitForSeconds(enemy.spawnInterval);
                    Spawn(enemy.enemyType);
                    enemiesLeft++;
                }

            }

            await new WaitForSeconds(wave.waveTime + nextWaveInterval);
            currentWave++;
        }

        void Spawn(int enemyType)
        {
            var spawnPoint = spawnPoints[0];
            Instantiate(enemiesType[enemyType], spawnPoint.position, Quaternion.identity);
        }

    }
}
