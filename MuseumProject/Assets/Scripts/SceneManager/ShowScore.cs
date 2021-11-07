using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowScore : ActionBase
{

    bool showDialogue = true;

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

    }

    public override void CustomUpdate(float deltaTime)
    {
        
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
