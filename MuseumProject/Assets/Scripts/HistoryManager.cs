using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HistoryManager : MonoBehaviour
{
    [SerializeField] string NextScene = "Game_1";
    [SerializeField] DynamicText[] List;
    [SerializeField] CanvasGroup LastCanvas;
    [SerializeField] float TimeLastCanvas = 3;

    DynamicText Current;
    int counter = 0;

    private void Awake()
    {
        Current = List[0];
    }

    private void FixedUpdate()
    {
        if (Current.HasDone)
        {
            counter++;
            if (counter < List.Length)
                Current = List[counter];
            else if (LastCanvas.alpha < 1)
            {
                LastCanvas.alpha += Time.fixedDeltaTime / TimeLastCanvas;
            }
            else
            {
                EndText();
            }
        }
        else
        {
            Current.CustomUpdate(Time.fixedDeltaTime);
        }
    }


    void EndText()
    {
        SceneManager.LoadScene(NextScene);
    }

}
