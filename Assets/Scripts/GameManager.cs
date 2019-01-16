﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Manager;

    public static  int PlayerLife;

    public static void DamagePlayer(int damage)
    {
        PlayerLife -= damage;
    }



    // Controls for the spawn rate
    public static float SpawnRate { get; set; }  // Should be accessible from any script with GameManager.Manager.SpawnRate 
    [SerializeField]
    private float SecondsToNextSpawn;

    private EnemySpawner[] enemySpawners;

    // Start is called before the first frame update
    void Start()
    {
        #region Singleton for GameManager
        // Singleton, so that there's only ever one Game Manager
        if (Manager != this)
        {
            Manager = this;
        } else
        {
            Destroy(this);
        }

        #endregion

        #region Establish Spawn Rates
        // Set a default spawn rate if none is applied
        if (SpawnRate == 0f)
        {
            SpawnRate = 2f;
        }

        SecondsToNextSpawn = SpawnRate;
        enemySpawners = FindObjectsOfType<EnemySpawner>();
        #endregion



    }

    // Update is called once per frame
    void Update()
    {
        #region Spawning logic
        // Spawn a new enemy at a random point every SpawnRate seconds
        SecondsToNextSpawn -= Time.deltaTime;

        if (SecondsToNextSpawn <= 0)
        {
            SpawnNewEnemy();
            SecondsToNextSpawn = SpawnRate;
        }
        #endregion

    }

    void SpawnNewEnemy()
    {
        int SpawnerNumber = Random.Range(0, enemySpawners.Length);

        enemySpawners[SpawnerNumber].Spawn();
    }

    public static void SpawnCustomEnemy(GameObject specialEnemy)
    {
        int SpawnerNumber = Random.Range(0, Manager.enemySpawners.Length);

        Manager.enemySpawners[SpawnerNumber].Spawn(specialEnemy);
    }

    public static void SpawnCustomEnemy(GameObject specialEnemy, int index)
    {
        if(index >= 0 && index <= Manager.enemySpawners.Length)
        {
            Manager.enemySpawners[index].Spawn(specialEnemy);
        } else
        {
            Debug.Log("Attempting to spawn " + specialEnemy + " but index " + index + " out of range");
        }
            

    }
}
