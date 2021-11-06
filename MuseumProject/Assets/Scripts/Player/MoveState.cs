using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : StateBase
{
    [SerializeField] KnockbackState knockbackState;
    [SerializeField] float TimeMoving = 1;
    float timer = 0;
    Vector2 SelectedDirection;

    Vector3 initPos;
    Vector3 endPos;
    public override void OnStateEnter()
    {
        base.OnStateEnter();

        timer = 0;

        SelectedDirection = Owner.LastDirection;

        initPos = Owner.transform.position;
        endPos = initPos;

        if(SelectedDirection.y > 0.1f)
        {
            endPos.x -= 1;
        }
        else if (SelectedDirection.y < -0.1f)
        {
            endPos.x += 1;
        }
        else if (SelectedDirection.x > 0.1f)
        {
            endPos.z += 1;
        }
        else if (SelectedDirection.x < -0.1f)
        {
            endPos.z -= 1;
        }
    }

    public override void CustomUpdate(float deltaTime)
    {
        base.CustomUpdate(deltaTime);

        timer += deltaTime;

        if (timer <= TimeMoving)
        {
            Vector3 posY = Vector3.zero;
            if(timer < TimeMoving / 2f)
            {
                Vector3 init = new Vector3(0, 0, 0);
                Vector3 end = new Vector3(0, Owner.JumpHeight, 0);

                posY = Vector3.Slerp(init, end, timer / (TimeMoving / 2f));

            }
            else
            {
                Vector3 init = new Vector3(0, Owner.JumpHeight, 0);
                Vector3 end = new Vector3(0, 0, 0);

                posY = Vector3.Slerp(init, end, (timer - TimeMoving / 2f) / (TimeMoving / 2));

            }

            Vector3 posH = Vector3.Lerp(initPos, endPos, timer / TimeMoving);

            Owner.transform.position = posY + posH;

        }
        else
        {
            Owner.transform.position = endPos;
            EndState();    
        }

    }

    public override void EndState()
    {
        base.EndState();
    }

    public override void Knockback()
    {
        base.Knockback();
        knockbackState.SetPositions(Owner.transform.position, initPos, timer);
        Owner.ChangeState(knockbackState);
    }

}
