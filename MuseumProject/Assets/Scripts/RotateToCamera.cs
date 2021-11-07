using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCamera : MonoBehaviour
{
   
    void Update()
    {
        Quaternion rot = transform.localRotation;
        var euler = rot.eulerAngles;

        Vector3 dir = CameraFollow.MainCamera.transform.position - transform.position;
        dir.y = 0;
        dir.Normalize();

        var currentDir = transform.forward;
        currentDir.y = 0;
        currentDir.Normalize();

        float dot = Mathf.Abs(Vector3.Dot(currentDir, dir));
        

        if (dot < 0.9999f)
        {
            float cross = Vector3.Cross(currentDir, dir).y;
            float deltaAngle = Mathf.Sign(cross) *Mathf.Acos(dot) * Mathf.Rad2Deg;

            euler.y += deltaAngle;

            rot.eulerAngles = euler;

            transform.localRotation = rot;
        }
    }
}
