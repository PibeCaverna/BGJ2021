using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDarkCanvasNow : ActionBase
{
    [SerializeField] CanvasGroup Canvas;
    public override void CustomUpdate(float deltaTime)
    {
       
       
    }

    public override void DoAction()
    {
        Canvas.gameObject.SetActive(true);
        Canvas.alpha = 1;
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
