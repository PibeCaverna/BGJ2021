using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] float threshold = 0.1f;

    [SerializeField] float Up = 90;
    [SerializeField] float Down = -90;
    [SerializeField] float Left = 180;
    [SerializeField] float Right = 0;

    public void SetDirection(Vector2 dir)
    {
        var rot = transform.rotation;
        if (dir.y >= threshold)
        {
            rot.eulerAngles = new Vector3(0, Up, 0);
        }
        else if (dir.y <= -threshold)
        {
            rot.eulerAngles = new Vector3(0, Down, 0);

        }
        else if (dir.x >= threshold)
        {
            rot.eulerAngles = new Vector3(0, Right, 0);
        }
        else if (dir.x <= -threshold)
        {
            rot.eulerAngles = new Vector3(0, Left, 0);

        }

        transform.rotation = rot;
    }
}
