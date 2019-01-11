using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{

    void OnCollisionEnter(Collision col) {

        BaseEnemy enemy = col.transform.GetComponent<BaseEnemy>();

        if (enemy)
        {
            enemy.TakeDamage(50);
        }

    }
}
