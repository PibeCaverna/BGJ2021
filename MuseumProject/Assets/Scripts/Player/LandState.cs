using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandState : StateBase
{

    [SerializeField] float TimeLanding = .5f;
    float timer = 0;

    public override void OnStateEnter()
    {
        base.OnStateEnter();

        timer = 0;

    }

    public override void CustomUpdate(float deltaTime)
    {
        base.CustomUpdate(deltaTime);
        timer += deltaTime;
        if(timer >= TimeLanding)
        {
            EndState();
        }

    }


}
