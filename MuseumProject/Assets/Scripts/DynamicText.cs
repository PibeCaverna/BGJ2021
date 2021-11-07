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

    int entercount = 0;

    bool spaceDown = false;
    bool waitkey = false;

    private void Update()
    {
        if (!waitkey) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceDown = true;
        }
    }

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
                {
                    waitkey = true;

                    if (entercount % 2 == 0)
                    {
                        if (TextField.text[TextField.maxVisibleCharacters] == '\n') entercount++;
                        TextField.maxVisibleCharacters += 1;

                        if (spaceDown)
                        {
                            waitkey = false;
                            spaceDown = false;

                            while(TextField.maxVisibleCharacters < TextField.text.Length && 
                                TextField.text[TextField.maxVisibleCharacters] != '\n')
                                TextField.maxVisibleCharacters += 1;

                        }
                    }
                    else
                    {
                        if (spaceDown)
                        {
                            TextField.maxVisibleCharacters += 2;
                            entercount++;
                            spaceDown = false;
                            waitkey = false;
                        }
                    }



                }
                else
                {
                    waiting = true;
                    waitkey = false;
                }
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
