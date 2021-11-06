using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionBase : MonoBehaviour
{
    public abstract void DoAction();

    public abstract void CustomUpdate(float deltaTime);
    
    public abstract bool IsDone();

    public abstract bool Transitioning();

}


