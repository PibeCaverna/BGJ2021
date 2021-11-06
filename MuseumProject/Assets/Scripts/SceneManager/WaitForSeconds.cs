using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForSeconds : ActionBase
{
    [SerializeField] float WaitSeconds = 3;
    float timer = 0;
    public override void CustomUpdate(float deltaTime)
    {
        timer += deltaTime;
    }

    public override void DoAction()
    {
        timer = 0;
    }

    public override bool IsDone()
    {
        return timer > WaitSeconds;
    }

    public override bool Transitioning()
    {
        return timer < WaitSeconds;
    }
}
