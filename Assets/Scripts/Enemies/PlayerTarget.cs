using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{

    void OnTriggerEnter(Collider collision)
    {
        GameManager.DamagePlayer(10);

        //  Destroy(gameObject);
    }
}
