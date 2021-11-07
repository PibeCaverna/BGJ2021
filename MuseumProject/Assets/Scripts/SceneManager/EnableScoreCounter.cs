using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableScoreCounter : ActionBase
{
    // Start is called before the first frame update
    [SerializeField] private ScoreCounter Counter;
    
    public override void DoAction()
    {
        Counter.StartCount();
    }

    public override void CustomUpdate(float deltaTime)
    {
        
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
