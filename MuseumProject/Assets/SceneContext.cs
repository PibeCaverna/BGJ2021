using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneContext : MonoBehaviour
{

    public static SceneContext Instance;
    [Header("Scenes")]
    [SerializeField] public string ThisScene;
    [SerializeField] public string NextScene;
    [Header("Actions")]
    [SerializeField] ActionBase[] ActionsAtStart;
    [SerializeField] ActionBase[] ActionsAtDeath;
    [SerializeField] ActionBase[] ActionsAtEnd;
    [SerializeField] ActionBase[] ActionsAtNotYet;
    int index = 0;

    bool starting = true;
    bool endScene = false;
    bool death = false;
    bool notyet = false;

    ActionBase CurrentAction;

    private void Awake()
    {
        Instance = this;
    }

    

    private void Update()
    {
        if (starting) ExecuteActions(Time.deltaTime, ActionsAtStart);
        if (death) ExecuteActions(Time.deltaTime, ActionsAtDeath);
        if (endScene) ExecuteActions(Time.deltaTime, ActionsAtEnd);
        if (notyet) ExecuteActions(Time.deltaTime, ActionsAtNotYet);
    }

    void ExecuteActions(float deltaTime, ActionBase[] ActionList)
    {
        if (index < ActionList.Length)
        {
            if (CurrentAction == null)
            {
                CurrentAction = ActionList[index];
                CurrentAction.DoAction();
            }
            else
            {
                if (CurrentAction.Transitioning())
                {
                    CurrentAction.CustomUpdate(deltaTime);
                }
                else
                {
                    index++;
                    if (index < ActionList.Length)
                    {
                        CurrentAction = ActionList[index];
                        CurrentAction.DoAction();
                    }
                    else
                    {
                        starting = false; 
                        endScene = false;
                        death = false;
                        notyet = false;
                        CurrentAction = null;
                        index = 0;
                    }
                }

            }
        }
    }



    public void Death()
    {
        death = true;
    }

    public void EndScene()
    {
        endScene = true;
    }

    internal void NotYet()
    {
        notyet = true;
    }
}
