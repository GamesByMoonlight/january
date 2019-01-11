using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementDumb : MonoBehaviour
{
    public float speed = 4;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 target = FindObjectOfType<RightArm>().transform.position;

        Vector3 direction = target - transform.position;

        direction.Normalize();

        Rigidbody rb = GetComponent<Rigidbody>();

        rb.velocity = direction * speed;
    }

    
}
