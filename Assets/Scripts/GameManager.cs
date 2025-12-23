using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameSettings settings;

    public static GameManager Instance { get; private set; }
    private GameObject _player;
    private Boolean _isPaused = false;
    private Boolean _isGameOver = false;
    

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

        LoadLevel(1);
    }

    private void LoadLevel(int levelNum)
    {
        /* загрузка уровня из json файла координаты игрока, врагов, вотор и тд */

        Level levelData = Resources.Load<Level>("Levels/Level" + levelNum.ToString());

        if (levelData != null)
        {
            GameObject playerObject = SpawnPlayer(
                levelData.playerPosition, levelData.playerRotation);

            if (playerObject != null)
            {
                _player = playerObject;
                SpawnAim();
                SpawnEnemy(levelData.enemyList);
            }           

        }
    }

    private GameObject SpawnPlayer(Vector2 spawnPoint, Quaternion rotation)
    {
        if (settings.playerPrefab != null && spawnPoint != null)
        {
            return Instantiate(settings.playerPrefab, spawnPoint, rotation);
        }

        Debug.LogError("Player Prefab or Spawn Point not assigned!");
        return null;
    } 

    private void SpawnAim()
    {
        if (settings.aimPrefab != null)
        {
            Instantiate(settings.aimPrefab, Vector2.zero, Quaternion.identity);            
        }
        else
        {
            Debug.LogError("Aim Prefab not assigned!");    
        }
       
    }      

    private void SpawnEnemy(List<EnemyData> enemyList)
    {
        if (settings.aimPrefab != null)
        {
            foreach (EnemyData enemyData in enemyList)
            {
                Instantiate(
                    enemyData.prefab, enemyData.position, enemyData.rotation);
            }
        }
        else
        {
            Debug.LogError("Enemy Prefab not assigned!");   
        }
    }

    public void PauseResume()
    {
        if (_isGameOver)
        {
            return;
        }

        _isPaused = !_isPaused;
        Time.timeScale = _isPaused ? 0f : 1f;
        //Cursor.visible = _isPaused;
        //Cursor.lockState = _isPaused ? CursorLockMode.None : CursorLockMode.Locked;
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

    public GameObject player => _player;

    public float weaponFiringRange => settings.weaponFiringRange;
    public float minWeaponFiringRange => settings.minWeaponFiringRange;
    public float weaponRotationSpeed => settings.weaponRotationSpeed;

    public float playerMovingSpeed => settings.playerMovingSpeed;

    public float playgroundWidth => settings.playgroundWidth;
    public float playgroundHeight => settings.playgroundHeight;

    public float enemyChasingDistance => settings.enemyChasingDistance;
    public float enemyMovingSpeed => settings.enemyMovingSpeed;
}

