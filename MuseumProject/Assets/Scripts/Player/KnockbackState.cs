using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackState : StateBase
{
    float TimeMoving;
    float timer = 0;
    Vector3 initPos;
    Vector3 endPos;

    public void SetPositions(Vector3 initPos, Vector3 endPos, float TimeMoving)
    {
        this.initPos = initPos;
        this.endPos = endPos;
        this.TimeMoving = TimeMoving;
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        timer = 0;
        Owner.LastDirection = -Owner.LastDirection;
    }

    public override void CustomUpdate(float deltaTime)
    {
        base.CustomUpdate(deltaTime);

        timer += deltaTime;

        if(timer <= TimeMoving)
        {
            Vector3 pos = Vector3.Slerp(initPos, endPos, timer / TimeMoving);
            Owner.transform.position = pos;
        }
        else
        {
            Owner.transform.position = endPos;
            Owner.Knockbacking = false;
            EndState();
        }

    }



}
