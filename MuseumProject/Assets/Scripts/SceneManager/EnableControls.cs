using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableControls : ActionBase
{
    [SerializeField] bool enableControls = true;
    [SerializeField] Character Character;
    public override void CustomUpdate(float deltaTime)
    {

    }

    public override void DoAction()
    {
        Character.enabled = enableControls;

    }

    public override bool IsDone()
    {
        return true;
    }

    public override bool Transitioning()
    {
        return false;
    }
}
