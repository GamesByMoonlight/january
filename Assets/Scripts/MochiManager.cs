using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MochiManager : MonoBehaviour
{
    public GameObject mochi;
    public Transform startPoint, endPoint;

    public void SpawnMochi(int mochiCount)
    {
        Vector3 spacing;
        
        if(mochiCount == 1)
        {
            spacing = (endPoint.localPosition - startPoint.localPosition);
        } else
        {
            spacing = (endPoint.localPosition - startPoint.localPosition) / (mochiCount - 1);
        }
        

        for (int i = 0; i < mochiCount; i++)
        {
            Vector3 spawnLocation;

            if(mochiCount == 1)
            {
                spawnLocation = startPoint.localPosition + (spacing / 2 );
            } else
            {
                spawnLocation = startPoint.localPosition + (spacing * i);
            }
            
            GameObject newMochi = Instantiate(mochi);

            newMochi.transform.parent = transform;
            newMochi.transform.localPosition = spawnLocation;
        }
    }

    public int CountMochi()
    {
        Mochi[] mochis = GetComponentsInChildren<Mochi>();
        return mochis.Length;
    }
}
