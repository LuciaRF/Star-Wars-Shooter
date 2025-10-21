using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform [] enemySpawnPosition;
    [SerializeField] private float timeBetweenEnemies;

    private void Start()
    {
        InvokeRepeating("CreateEnemies",timeBetweenEnemies,timeBetweenEnemies);
    }

    void CreateEnemies()
    {
        int n = Random.Range(0,enemySpawnPosition.Length);
        
        Instantiate(enemyPrefab, enemySpawnPosition[n].position, enemySpawnPosition[n].rotation);
    }
        
}
