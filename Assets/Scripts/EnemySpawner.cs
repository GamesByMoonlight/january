using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject defaultEnemy;

    public void Spawn()
    {
        if(defaultEnemy == null)
        {
            Debug.Log("defaultEnemy property of " + this + " is not assigned an object");
            return;
        }

        if (defaultEnemy.GetComponent<BaseEnemy>() == null)
        {
            Debug.Log("defaultEnemy property of " + this + " is not assigned an object that is a BaseEnemy");
            return;
        }
            
        GameObject newEnemy = Instantiate(defaultEnemy, transform.position, Quaternion.identity);

        newEnemy.SendMessage("Spawn");
        newEnemy.transform.parent = transform;
    }

    public void Spawn(GameObject enemyToSpawn)
    {
        if(enemyToSpawn.transform.GetComponent<BaseEnemy>() == null)
        {
            Debug.Log("Attempting to spawn " + enemyToSpawn + " at " + this + " but " + enemyToSpawn +" is not inheriting from BaseEnemy");
            return;
        }
        
        GameObject newEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);

        newEnemy.SendMessage("Spawn");
        newEnemy.transform.parent = transform;
        
            
    }
}
