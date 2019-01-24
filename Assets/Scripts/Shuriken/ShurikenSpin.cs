using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// =============================================
///  Class to make the shuriken spin.
///  
///  Place on the model level of the shuriken prefab
///  
///  Should be easily modified later if we want the shuriken to "stick" on collision
/// =============================================

public class ShurikenSpin : MonoBehaviour
{
    public bool IsRotating { get; set; } 

    void Start()
    {
        IsRotating = true;
    }

    
    void Update()
    {
        if (IsRotating)
        {
            transform.eulerAngles += new Vector3(0f, Time.deltaTime * 600, 0f);
        }
    }

    public void StopRotation()
    {
        IsRotating = false;
    }
}
