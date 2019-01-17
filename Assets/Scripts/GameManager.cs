using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Manager;
    public Text textHealth;
    public Text textWin;
    public static Text textLose;
    public static int PlayerLife=100;
    public int mochiCount = 3;

    private static MochiManager mochiManager;

    // Controls for the spawn rate
    public static float SpawnRate { get; set; }  // Should be accessible from any script with GameManager.Manager.SpawnRate 
    [SerializeField]
    private float SecondsToNextSpawn;

    private EnemySpawner[] enemySpawners;

    // Start is called before the first frame update
    void Start()
    {
        #region Singleton for GameManager

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
        if (SpawnRate <= 0.1f)
        {
            SpawnRate = 2f;
        }

        SecondsToNextSpawn = SpawnRate;
        enemySpawners = FindObjectsOfType<EnemySpawner>();
        #endregion

        #region Reference for MochiManager, initial Mochi spawn

        mochiManager = FindObjectOfType<MochiManager>();
        if (!mochiManager)
        {
            Debug.LogError("Could not find MochiManager in scene");
        } else
        {
            mochiManager.SpawnMochi(mochiCount);
        }
        #endregion

      
 
    }

 
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

        textHealth.text = PlayerLife.ToString();

        if (PlayerLife <= 1)
        {
            textWin.text = "GAME OVER";

        }
    }

    #region Methods related to damaging player, losing the level

    


    public static void DamagePlayer(int damage)
    {
        PlayerLife -= damage;    

    }

    #endregion

    #region Methods related to winning the level
    public static void CheckForEndGame()
    {
        Manager.StartCoroutine(Manager.DelayCounting());  
    }

    IEnumerator DelayCounting()
    {
        yield return new WaitForEndOfFrame();

        try
        {
            if (mochiManager.CountMochi() <= 0)
            {
                Manager.PlayerWin();
            }
        } catch
        {
            Debug.LogWarning("Attempting to reference mochiManager, but mochiManager reference in GameManager is broken");
        }


    }

    void PlayerWin()
    {
       // Debug.Log("Player wins!");

        textWin.text = "Player wins!";

    }




    #endregion

    #region Methods to control spawning enemies

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

    #endregion  
}
