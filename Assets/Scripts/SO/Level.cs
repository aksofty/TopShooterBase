using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Scriptable Objects/Level")]
public class Level : ScriptableObject
{
    public Vector2 playerPosition;
    public Quaternion playerRotation;  
    public List<EnemyData> enemyList;
}

[System.Serializable]
public class EnemyData
{
    public GameObject prefab;
    public Vector2 position;
    public Quaternion rotation;   
}
