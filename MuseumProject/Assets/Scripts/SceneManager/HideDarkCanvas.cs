using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideDarkCanvas : ActionBase
{
    [SerializeField] CanvasGroup Canvas;
    public override void CustomUpdate(float deltaTime)
    {
        
        if(Canvas.alpha > 0)
            Canvas.alpha -= deltaTime;
        else
            Canvas.gameObject.SetActive(false);
    }

    public override void DoAction()
    {

    }

    public override bool IsDone()
    {
        return Canvas.alpha <= 1;
    }

    public override bool Transitioning()
    {
        return Canvas.alpha > 0;
    }
}
