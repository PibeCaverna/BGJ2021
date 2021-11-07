using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : ActionBase
{
    public override void CustomUpdate(float deltaTime)
    {

    }

    public override void DoAction()
    {
        SoundManager.Instance.StopMusic();
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
