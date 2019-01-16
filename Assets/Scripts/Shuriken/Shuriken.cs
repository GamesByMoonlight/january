using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    private float duration = 0.0f;
    private float MaxDuration = 5.0f;


    void OnCollisionEnter(Collision col) {

        BaseEnemy enemy = col.transform.GetComponent<BaseEnemy>();

        if (enemy)
        {
            // Damage enemy and destory object.
            enemy.TakeDamage(50);
            Destroy(this.gameObject);
        }

    }

    private void Update()
    {
        duration += Time.deltaTime;
        if (duration > MaxDuration)
            Destroy(this.gameObject);
    }
}
