using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{

    void OnCollisionEnter(Collision col) {
        

        if (col.transform.CompareTag("Enemy")){
            Enemy enemy = col.transform.GetComponent<Enemy>();

            enemy.TakeDamage(50);
        }

    }
}
