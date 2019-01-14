using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}

    


