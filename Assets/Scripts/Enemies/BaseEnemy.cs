using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// BaseEnemy should be used as a base class for all Enemy types

[RequireComponent(typeof(Collider))]
public class BaseEnemy : MonoBehaviour
{
    public float health = 50f;

    public void Spawn()
    {
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }


    [SerializeField]
    Transform _destination;

    NavMeshAgent _navMeshAgent;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = 11;  // All enemies should be on the enemy layer for collision purposes

        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        if (_navMeshAgent == null)
        {
            Debug.Log("NavMesh  Agent required");
        }
        else
        {
            //YamadaSensei

            SetDestination();
        }


    }

    public GameObject player;
    private void SetDestination()
    {

        player = GameObject.FindGameObjectWithTag("PlayerTarget");
        
        //Vector3 targetVector = _destination.transform.position;
        Vector3 targetVector = player.transform.position;
        _navMeshAgent.SetDestination(targetVector);

    }

}

    


