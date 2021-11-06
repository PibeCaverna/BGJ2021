using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHeadAnimation : ActionBase
{
    [SerializeField] Character Character;
    bool end = false;

    float timer = 1;
    int count = 0;

    public override void CustomUpdate(float deltaTime)
    {
        if (end) return;
        timer += deltaTime;
        if(timer > 1)
        {
            timer = 0;
            count++;
            if (count < 3)
            {
                Character.SpriteDirection.Renderer.flipX = !Character.SpriteDirection.Renderer.flipX;
            }
            else
            {
                end = true;
            }
        }
    }

    public override void DoAction()
    {
        end = false;
        timer = 1;
    }

    public override bool IsDone()
    {
        return end;
    }

    public override bool Transitioning()
    {
        return !end;
    }
}
