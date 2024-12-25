using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public int waveNumber;
        public List<EnemyGroup> enemyGroups; // A list of groups of enemies to spawn in this wave
        public int waveQuota;   // total number of enemies to spawn in this wave
        public float spawnInterval;     //The interval at which enemies will spawn
        public float spawnCount;    // The amount of enemies already spawned in this wave
    }

    [System.Serializable]
    public class EnemyGroup
    {
        public GameObject enemyPrefab;
        public string enemyName; // Name of enemy
        public int enemyCount; // Number of enemies to spawn
        public int spawnedCount; // Number of enemies already spawned
    }

    public List<Wave> waves;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
