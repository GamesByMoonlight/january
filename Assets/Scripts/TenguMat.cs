using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenguMat : MonoBehaviour
{

    Material mat;
    SkinnedMeshRenderer mr;

        // Start is called before the first frame update
    void Start()
        {
            mr = GetComponent<SkinnedMeshRenderer>();
            mat = new Material(mr.material);

            mr.material = mat;

        }
 

    // Update is called once per frame
    void Update()
    {
        
    }
}
