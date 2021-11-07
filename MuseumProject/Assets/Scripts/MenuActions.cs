using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] Button StartButton;
    [SerializeField] Button CreditsButton;
    [SerializeField] Button ExitButton;

    [SerializeField] string NextScene;
    [SerializeField] GameObject CreditsPanel;


    public void StartGame()
    {
        StartButton.enabled = false;
        SceneManager.LoadScene(NextScene);
    }

    public void HideCredits()
    {
        CreditsButton.enabled = true;
        CreditsPanel.SetActive(false);
        //gameObject.SetActive(true);
    }

    public void ShowCredits()
    {
        CreditsButton.enabled = false;
        //gameObject.SetActive(false);
        CreditsPanel.SetActive(true);

    }

    public void ShowAcceptExit()
    {

    }

    public void HideAcceptExit()
    {

    }

    public void Exit()
    {
        ExitButton.enabled = false;
        Application.Quit();
    }
}
