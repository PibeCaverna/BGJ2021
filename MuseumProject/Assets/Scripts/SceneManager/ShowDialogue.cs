using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDialogue : ActionBase
{

    bool showDialogue = true;

    [SerializeField] string[] Dialogues;
    [SerializeField] TMPro.TextMeshProUGUI Text;
    [SerializeField] CanvasGroup DialogueCanvas;
    int index = 0;

    public override void CustomUpdate(float deltaTime)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            index++;
            if(index < Dialogues.Length)
            {
                Text.text = Dialogues[index];
            }
            else
            {
                showDialogue = false;
                DialogueCanvas.gameObject.SetActive(false);
            }
        }
    }

    public override void DoAction()
    {
        DialogueCanvas.gameObject.SetActive(true);
        index = 0;
        showDialogue = true;
        Text.text = Dialogues[index];

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
