using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DynamicText : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI TextField;
    [SerializeField] CanvasGroup CanvasGroup;
    [SerializeField] float TimeShowingCanvas = 2f;
    [SerializeField] float TimeWaitingCanvas = 2f;
    [SerializeField] float TimeWritting = .2f;
    [SerializeField] float TimeAfter = 5;
    string text;

    float timer = 0;
    float timer2 = 0;

    bool waiting = false;

    private void Awake()
    {
        HasDone = false;
        TextField.maxVisibleCharacters = 0;
        text = TextField.text;
    }

    public bool HasDone { get; protected set; }

    

    public void CustomUpdate(float deltaTime)
    {
        timer += deltaTime;
        if (!waiting)
        {
            if(CanvasGroup.alpha < 1)
            {
                CanvasGroup.alpha += deltaTime / TimeShowingCanvas;
            }
            else if(timer2 < TimeWaitingCanvas)
            {
                timer2 += deltaTime;
            }
            else if (timer >= TimeWritting)
            {
                timer = 0;
                if (TextField.maxVisibleCharacters < TextField.text.Length)
                    TextField.maxVisibleCharacters += 1;
                else waiting = true;
            }
        }
        else
        {
            if(timer > TimeAfter)
            {
                HasDone = true;
            }
        }
        
    }


}
