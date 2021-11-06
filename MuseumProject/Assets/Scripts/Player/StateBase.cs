using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase : MonoBehaviour
{
    [SerializeField] protected Character Owner;

    [SerializeField] SoundData EnterSound;
    [SerializeField] SoundData EndSound;

    [SerializeField] protected StateBase OnMove;
    [SerializeField] protected StateBase OnEndState;

    
    

    public virtual void OnStateEnter()
    {
        if (EnterSound)
        {
            SoundManager.Instance.PlayEffect(EnterSound.GetRandom());
        }
    }

    public virtual void CustomUpdate(float deltaTime)
    {

    }

    public virtual void EndState()
    {
        if (EndSound)
        {
            SoundManager.Instance.PlayEffect(EndSound.GetRandom());
        }
        Owner.ChangeState(OnEndState);

    }

    public virtual void Knockback()
    {

    }



}
