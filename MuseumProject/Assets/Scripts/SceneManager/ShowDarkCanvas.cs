using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDarkCanvas : ActionBase
{
    [SerializeField] CanvasGroup Canvas;
    public override void CustomUpdate(float deltaTime)
    {
       
        if(Canvas.alpha <1)
            Canvas.alpha += deltaTime;
    }

    public override void DoAction()
    {
        Canvas.gameObject.SetActive(true);
    }

    public override bool IsDone()
    {
        return Canvas.alpha >= 1;
    }

    public override bool Transitioning()
    {
        return Canvas.alpha < 1;
    }
}
