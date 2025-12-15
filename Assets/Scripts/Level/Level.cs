using System;
using UnityEngine;

public class Level : MonoBehaviour
{


    private void OnEnable()
    {
        EventBus.OnGameOver += GameOver;
        EventBus.OnGamePaused += Pause;
        EventBus.OnGameResumed += Resume;
    }

    private void OnDisable()
    {
        EventBus.OnGameOver -= GameOver;
        EventBus.OnGamePaused -= Pause;
        EventBus.OnGameResumed -= Resume;
    }
    

    private void Resume()
    {
        Time.timeScale = 1f;   
    }

    private void Pause()
    {
        Time.timeScale = 0f;    
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
    }
}
