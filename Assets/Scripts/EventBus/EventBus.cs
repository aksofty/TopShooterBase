using System;
using UnityEngine;

public static class EventBus
{
    public static Action OnGamePaused; // Игра на паузе
    public static Action OnGameResumed; // Игра возобновлена
    public static Action OnGameOver; // Игра окончена

    public static void GameOver()
    {
        Debug.Log($"EventBus: Игра окончена");
        OnGameOver?.Invoke();
    }

    public static void GamePaused()
    {
        Debug.Log($"EventBus: Игра остановлена");
        OnGamePaused?.Invoke();
    }

    public static void GameResumed()
    {
        Debug.Log($"EventBus: Игра возобновлена");
        OnGameResumed?.Invoke();
    }

   
}