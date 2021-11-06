using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : ActionBase
{
    [SerializeField] SoundData Music;
    public override void CustomUpdate(float deltaTime)
    {

    }

    public override void DoAction()
    {
        SoundManager.Instance.ChangeMusic(Music.GetRandom(), 0, true);
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
