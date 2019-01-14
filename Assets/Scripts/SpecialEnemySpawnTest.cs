using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemySpawnTest : MonoBehaviour
{
    GameObject redGuy;

    // Start is called before the first frame update
    void Start()
    {
        redGuy = (GameObject)Resources.Load("Red Enemy Test", typeof(GameObject));
        InvokeRepeating("SpawnRedGuy", 5f, 5f);
    }

    void SpawnRedGuy()
    {
        GameManager.SpawnCustomEnemy(redGuy);
    }

}
