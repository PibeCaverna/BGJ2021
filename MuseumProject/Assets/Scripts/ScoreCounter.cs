using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreCounter : MonoBehaviour
{
    private float initTime;
    private float finishTime;
    private float totalTime;
    private int score;
    [SerializeField] int maxScore;
    [SerializeField] float scoreRate;
    public void StartCount()
    {
        initTime = Time.time;
    }

    public void Update()
    {
        var curTime = Time.time - initTime;
        Debug.Log(curTime);
        var scoreStep = curTime * scoreRate;
        Debug.Log((int) (maxScore - (scoreStep * scoreStep)));
    }


    public void StopCount()
    {
        finishTime = Time.time;
        totalTime = finishTime - initTime;
    }


    public int GetScore()
    {
        var scoreStep = totalTime * scoreRate;
        score = (int) (maxScore - (scoreStep * scoreStep));
        return score;
    }
}
