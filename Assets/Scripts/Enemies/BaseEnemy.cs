using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

// BaseEnemy should be used as a base class for all Enemy types
// Using this guarantees the spawner will spawn it correctly, and that the enemy can be destroyed
// Also guarantees the Spawn and TakeDamage methods are avaliable to be referenced by other objects

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(NavMeshAgent))]
public class BaseEnemy : MonoBehaviour
{
    public float health = 50f;
    
    public void Spawn()
    {
    }

    public void DealDamage(float amount)
    {
        GameManager.DamagePlayer(Mathf.FloorToInt(amount));
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            SendMessage("Die");     // This hack will send the "Die" message to child classes, instead of calling this "Die"
        }
    }

    /// Specialized death animations should be implemented by child classes
    void Die()
    {
        Debug.Log("Using default Die method on BaseEnemy");
        Destroy(gameObject, 0.5f);
    }


    
    [SerializeField]
    Transform _destination;

    NavMeshAgent _navMeshAgent;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        gameObject.layer = 11;  // All enemies should be on the enemy layer for collision purposes

        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        if (_navMeshAgent == null)
        {
            Debug.Log("NavMesh  Agent required");
        }
        else
        {
            // SetDestination();
     
            GetWayPoints();

        }


    }

    public GameObject player;
    //private void SetDestination()
    //{
    //    player = GameObject.FindGameObjectWithTag("PlayerTarget");
    //    //Vector3 targetVector = _destination.transform.position;
    //    Vector3 targetVector = player.transform.position;
    //    _navMeshAgent.SetDestination(targetVector);
    //}



    public const int zones =5;// must use one less than the number of zones
                              //    public GameObject[] WayPoints;
    public List<GameObject> WayPoints = new List<GameObject>();
    public List<GameObject> EnemyWayPoints= new List<GameObject>();

    private void GetWayPoints()
    {
        //WayPoints = GameObject.FindGameObjectsWithTag("WayPoints");
        //WayPoints.AddRange(GameObject.FindGameObjectsWithTag("WayPoints").OrderBy(g => g.transform.GetSiblingIndex()).ToArray());

       //WayPoints.AddRange(GameObject.FindGameObjectsWithTag("WayPoints").OrderBy(x => x.transform.position.z));
        WayPoints.AddRange(GameObject.FindGameObjectsWithTag("WayPoints").OrderByDescending(x => x.transform.position.z));

        //foreach (GameObject go in GameObject.FindGameObjectsWithTag("WayPoints").OrderBy(x => x.transform.position.x))
        //{
        //    WayPoints.Add(go);
        //}

        // Debug.Log( "Number of waypoints"+ WayPoints.Length.ToString());
        int minn = 0;
        int maxx = 0;
        for (int i = 0; i < zones; i++)
        {
            minn = i * zones;       // 0,4,8,12    .... 0, 5, 10, 15, 20
            maxx = (i + 1) * zones;   // 4,8,12,16   .... 5,10, 15, 20, 25
                                    //            
            int r = Random.RandomRange(minn, maxx);
            //int r =(int)Random.Range((float)minn, (float)maxx);
            EnemyWayPoints.Add(WayPoints[r]);
            //Debug.Log("RandomNumber...." + r +" mn ..." + minn + " mx.." +maxx);

        }

    }


    public int currentWayPoint =0; 
    void GoToNextPoint()
    {
        if (currentWayPoint <= zones-1)
        {
            //
            //Debug.Log("going to waypoint" + currentWayPoint);

            _navMeshAgent.SetDestination(EnemyWayPoints[currentWayPoint].transform.position);

            transform.LookAt(EnemyWayPoints[currentWayPoint].transform.position);
            _navMeshAgent.autoBraking = false;  /// this keeps the enemy from stopping at each waypoint

            
            currentWayPoint++;
        }

        if (currentWayPoint>=4)
        {
           
            transform.LookAt(player.transform.position);
        }

    }

    void Update()
    {
        // Choose the next destination point when the agent gets close to the current one.
        if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.2f)
        {
              GoToNextPoint();
        }


        if (!_navMeshAgent.pathPending && _navMeshAgent.remainingDistance < 0.2f && currentWayPoint >= 4 )
        {
            _navMeshAgent.autoBraking = true;

            anim = GetComponent<Animator>();


            anim.SetBool("Attack", true);
            transform.LookAt(player.transform.position);

            _navMeshAgent.isStopped = true;



        }


    }
    





}


    


