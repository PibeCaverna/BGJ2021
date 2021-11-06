using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] float speed = 1;

    float t = 0;
    Vector3 lastPosition;
    private void FixedUpdate()
    {

        if (Target)
        {
            if (!IsOverTarget())
            {
                float distance = Vector3.Distance(Target.position, lastPosition);
                t += Time.fixedDeltaTime / distance * speed;

                Vector3 pos = Vector3.Lerp(lastPosition, Target.position, t);
                transform.position = pos;
            }
        }
    }

    public void SetTarget(Transform target)
    {
        lastPosition = Target.position;
        Target = target;
        t = 0;
    }

    public bool IsOverTarget()
    {
        return Vector3.Distance(Target.position, transform.position) < 0.1f;
    }
}
