using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : ActionBase
{
    [SerializeField] BonesViewer BonesViewer;
    public override void CustomUpdate(float deltaTime)
    {

    }

    public override void DoAction()
    {
        BonesViewer.ShowCameraTransition();
    }

    public override bool IsDone()
    {
        return !BonesViewer.Transition;
    }

    public override bool Transitioning()
    {
        return BonesViewer.Transition;
    }
}
