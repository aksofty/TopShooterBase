using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameSettings settings;
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _level;

    public static GameManager Instance { get; private set; }

    private Boolean _isPaused = false;
    private Boolean _isGameOver = false; 

    private void InitLevel()
    {
        _level.SetActive(true);
    }

    private void Awake()
    {
        Debug.Log("Awake gamemanager");  

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        InitLevel();
    }

    public void PauseResume()
    {
        if (_isGameOver)
        {
            return;
        }

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
        _isGameOver = true;
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public Boolean isPaused => _isPaused;

    public Transform player => _player;

    public float playerMovingSpeed => settings.playerMovingSpeed;

    public float playgroundWidth => settings.playgroundWidth;
    public float playgroundHeight => settings.playgroundHeight;

    public float enemyChasingDistance => settings.enemyChasingDistance;
    public float enemyMovingSpeed => settings.enemyMovingSpeed;
}

