using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenThrower : MonoBehaviour
{
    [SerializeField]
    Shuriken shurikenPrefab;

    GameObject handTracker;
    Transform cameraTransform;
    Transform shurikenTurnPoint;

    public float shurikenSpeed;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            handTracker = GameObject.FindGameObjectWithTag("ShurikenSpawnPoint");
        } catch
        {
            Debug.LogError(this + " could not find a an object with tag ShurikenSpawnPoint");
        }

        try
        {
            shurikenTurnPoint = GameObject.FindGameObjectWithTag("ShurikenTurnPoint").transform;
        }
        catch
        {
            Debug.LogError(this + " could not find an object with tag ShurikenTurnPoint");
        }

        try
        {
            cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        } catch
        {
            Debug.LogError(this + " could not find an object with tag MainCamera");
        }
    }

    
    // Called by an event in the animation "Throw Shuriken"
    public void ThrowShuriken()
    {
        var shuriken = Instantiate(shurikenPrefab, handTracker.transform.position, Quaternion.identity);

        // Passing a lot of information over to the Shuriken to make it fly correctly.  This is a mess, but seems best???
        shuriken.VelocityCorrection(handTracker.transform.position, 
                                    shurikenTurnPoint.position, 
                                    (shurikenTurnPoint.position - cameraTransform.position).normalized, 
                                    shurikenSpeed);
    }
}
