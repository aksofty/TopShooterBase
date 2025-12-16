using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private Boolean _isPaused = false;
    private Boolean _isGameOver = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // Позволяет объекту не удаляться при переходе между сценами
        DontDestroyOnLoad(gameObject);
    }

    public void PauseResume()
    {
        _isPaused = !_isPaused;
        Time.timeScale = _isPaused ? 0f : 1f;
        Cursor.visible = _isPaused;
        Cursor.lockState = _isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        /*if (pauseMenuUI != null && _isPaused)
        {
            pauseMenuUI.SetActive(false); 
        }*/
    }

    public void GameOver()
    {
        _isGameOver = false;
        Time.timeScale =  0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;   
    }
}

