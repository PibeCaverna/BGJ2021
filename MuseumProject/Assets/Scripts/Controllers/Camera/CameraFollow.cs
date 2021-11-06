using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow MainCamera;

    [SerializeField] Vector3 offset;
    [SerializeField] float t = 0.5f;
    [SerializeField] float StepTime = 1f / 30f;

    float timer = 0;

    private void Awake()
    {
        MainCamera = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        //if(timer > StepTime)
        {
            timer = 0;
            var targetPos = CameraFollowTarget.Target.transform.position;
            targetPos.y = 0;
            var newpos = offset + targetPos;
            transform.position = Vector3.Lerp(transform.position, newpos, t);
        }
    }

    public bool HasOverTarget()
    {
        var targetPos = CameraFollowTarget.Target.transform.position;
        targetPos.y = 0;
        var newpos = offset + targetPos;

        return (Vector3.Distance(transform.position, newpos) < 0.01f);

    }

}
