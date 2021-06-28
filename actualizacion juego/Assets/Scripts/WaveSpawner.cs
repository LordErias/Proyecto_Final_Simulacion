using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public float timeBetweenWaves = 10f;
    public float timeBeteenEnemies = 1f;
    public float countdownWaves = 2f;
    public float countdownEnemies = 2f;

    private int waveNumber = 1;
    public GameObject spawners;
    private GameObject[] enemies;
    private Stack<int> enemiesStack;
    private int EnemiesLeft;
    public bool onWave = false;
    
    void Start()
    {
        enemiesStack = new Stack<int>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        EnemiesLeft = 0;
    }

    void Update()
    {
        if (countdownWaves <= 0)
        {
            countdownWaves = timeBetweenWaves;
        }
        if (enemies.Length < 1 && countdownWaves <= 0)
        {
            spawnWave();
            // onWave = true;
        }
        if (countdownEnemies <= 0 && EnemiesLeft > 0 )
        {
            spawnEnemy();
            EnemiesLeft = enemiesStack.Pop();
            if (EnemiesLeft == 0)
            {
                // onWave = false;
            }
            countdownEnemies = timeBeteenEnemies;
        }


        countdownEnemies -= Time.deltaTime;
        countdownWaves -= Time.deltaTime;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void spawnWave(){
        int enemyCount = waveNumber * waveNumber + 1;
        print(enemyCount);
        for (int i = 0; i < enemyCount; i++)
        {
            enemiesStack.Push(i);
        }
        EnemiesLeft = enemiesStack.Peek();
        waveNumber ++;
    }
    void spawnEnemy(){
        spawners.GetComponent<SpawnManager>().spawnNewEnemy();
    }
}
