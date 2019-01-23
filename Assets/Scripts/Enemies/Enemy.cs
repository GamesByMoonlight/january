using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : BaseEnemy
{

    [SerializeField]
    GameObject rays;
    [SerializeField]
    GameObject smoke;

    public new void Spawn()
    {
        GameObject newSmoke = Instantiate(smoke, transform.position, Quaternion.identity);
        Destroy(newSmoke, 1f);
    }

    void Die()
    {
        GameObject newRays = Instantiate(rays, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
        Destroy(gameObject, 1.5f);
        Destroy(newRays, 1.5f);

        try
        {
            GetComponent<Animator>().SetTrigger("death");
        } catch
        {
            Debug.Log("Failed to find Animator on " + gameObject);
        }

        try
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
        } catch
        {
            Debug.Log("Failed attempt to modify RigidBody on " + gameObject);
        }

        try {
            GetComponent<NavMeshAgent>().isStopped = true;
        }
        catch
        {
            Debug.LogWarning("Could not find Nav Mesh Agent on " + gameObject);
        }
    }

}
