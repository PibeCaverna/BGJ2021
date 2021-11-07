using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowScore : ActionBase
{

    bool showDialogue = true;

    bool start = false;

    private string score;
    [SerializeField] TMPro.TextMeshProUGUI Text;
    [SerializeField] CanvasGroup ScoreCanvas;
    [SerializeField] ScoreCounter Counter;
    
    

    public override void DoAction()
    {
        score = Counter.GetScore().ToString();
        ScoreCanvas.gameObject.SetActive(true);
        showDialogue = true;
        Text.text = "SCORE: " + score;
        start = true;
    }

    public override void CustomUpdate(float deltaTime)
    {
        if (Input.GetKeyDown(KeyCode.Space)) showDialogue = false;
    }

    public override bool IsDone()
    {
        return !showDialogue;
    }

    public override bool Transitioning()
    {
        return showDialogue;
    }

}
