using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateBase
{
    float timer = 0;
    [SerializeField] float Amplitude = .2f;
    [SerializeField] float Frecuency = 1;
    
    Vector3 CurrentPosition;

    public override void OnStateEnter()
    {
        timer = 0;
        base.OnStateEnter();
        var pos = Owner.transform.position;
        pos.x = (int)pos.x;
        pos.z = (int)pos.z;
        pos.y = Owner.MinHeight;

        CurrentPosition = pos;
        Owner.transform.position = pos;

    }

    public override void CustomUpdate(float deltaTime)
    {
        base.CustomUpdate(deltaTime);

        timer += deltaTime;

        var deltaPos = Vector3.zero;

        deltaPos.y = Mathf.Sin(timer*Mathf.PI*Frecuency) * Amplitude;

        Owner.transform.position = CurrentPosition + deltaPos;

        if(Owner.Controller.inputReader.Stick.magnitude > .1f)
        {
            EndState();
        }

    }

    public override void EndState()
    {
        Owner.transform.position = CurrentPosition;
        base.EndState();

    }

}
