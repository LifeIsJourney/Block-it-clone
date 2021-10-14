using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] Ball ball;
    bool showingGameEndScreen;
    [SerializeField] GameObject gameEndScreenGo;
    public bool playing;
    public void QuitTheApplication()
    {
        Application.Quit();
    }

    public void ShowGameEndScreen()
    {
        showingGameEndScreen = !showingGameEndScreen;
        gameEndScreenGo.SetActive(showingGameEndScreen);
    }

    public void RestartTheGame()
    {
        ball.Reset();
        ShowGameEndScreen();
        playing=true;
    }
}
