using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : ActionBase
{
    [SerializeField] bool thisScene;
    public override void CustomUpdate(float deltaTime)
    {

    }

    public override void DoAction()
    {
        if (thisScene)
        {

            SceneManager.LoadScene(SceneContext.Instance.ThisScene);
        }
        else
        {
            SceneManager.LoadScene(SceneContext.Instance.NextScene);
        }
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
