using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookControls : MonoBehaviour
{

    // Someone cool might want to make these variable in an options menu
    public float horizontalSpeed = 2.0f;
    public float verticalSpeed = 2.0f;
    public bool invert = true;

    private float pitch, yaw;

    // Update is called once per frame
    void Update()
    {
        pitch += (invert ? verticalSpeed : -verticalSpeed) * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        yaw += horizontalSpeed * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(pitch, yaw, 0);
    }
}
