using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/GameSettings")]
public class GameSettings : ScriptableObject
{

    [Header("Настройки игрока")]
    public GameObject playerPrefab;
    public float playerMovingSpeed = 5f;

    [Header("Настройки игрового поля")]
    public float playgroundWidth = 16f;
    public float playgroundHeight = 8f;

    [Header("Настройки врагов")]    
    public GameObject enemyPrefab;
    public float enemyChasingDistance = 5f;
    public float enemyMovingSpeed = 1f;


}
