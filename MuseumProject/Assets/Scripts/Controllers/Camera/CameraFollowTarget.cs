using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    [SerializeField] Character Character;
    public static Transform Target;

    private void Awake()
    {
        Target = this.transform;
    }

    private void FixedUpdate()
    {
        var pos = transform.position;
        pos.y = Character.MinHeight;
        transform.position = pos;
    }

    public void ReturnToFocusTarget()
    {
        Target = this.transform;
    }
}
