using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mochi : MonoBehaviour
{
    public float eatTime = 2f;
    
    private float eatTimeRemaining;

    public void BeginEating()
    {
        StartCoroutine(Eat());
        
    }

    IEnumerator Eat()
    {
        eatTimeRemaining = eatTime;
        
        while(eatTimeRemaining > 0)
        {
            eatTimeRemaining -= Time.deltaTime;
            yield return null;
        }

        FinishMochi();
    }

    void FinishMochi()
    {
        GameManager.CheckForEndGame();
        Destroy(gameObject);
    }
}
