using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BaseEnemy should be used as a base class for all Enemy types

public abstract class BaseEnemy : MonoBehaviour
{
    public float health = 50f;

    public abstract void Spawn();
    public abstract void TakeDamage(float damage);

}
