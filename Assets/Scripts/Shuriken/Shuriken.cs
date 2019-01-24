using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    private float duration = 0.0f;
    private float MaxDuration = 10.0f;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col) {

        BaseEnemy enemy = col.transform.GetComponent<BaseEnemy>();

        if (enemy)
        {
            // Damage enemy and destory object.
            enemy.TakeDamage(50);
        }

        Hit();

        GetComponent<Collider>().enabled = false; // Just to keep other bad guys from walking into this shuriken
    }

    private void Hit()
    {
        rb.collisionDetectionMode = CollisionDetectionMode.Discrete;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;

        rb.constraints = RigidbodyConstraints.FreezeAll;

        BroadcastMessage("StopRotation");
        
        Destroy(gameObject, 1f);
    }

    private void Update()
    {
        duration += Time.deltaTime;
        if (duration > MaxDuration)
            Destroy(gameObject);
    }

    public void VelocityCorrection(Vector3 startPoint, Vector3 turnPoint, Vector3 initialVelocityVector, float shurikenSpeed)
    {
        StartCoroutine(ResetVelocity(startPoint, turnPoint, initialVelocityVector, shurikenSpeed));
    }

    IEnumerator ResetVelocity(Vector3 startPoint, Vector3 turnPoint, Vector3 initialVelocityVector, float shurikenSpeed)
    {
        float turnRange = Vector3.Magnitude(turnPoint - startPoint);

        rb.velocity = (turnPoint - startPoint).normalized * shurikenSpeed;

        while(Vector3.Magnitude(transform.position - startPoint) < turnRange)
        {
            yield return new WaitForEndOfFrame();
        }

        rb.velocity = initialVelocityVector * shurikenSpeed;
    }
}
