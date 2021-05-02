using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Level_#", menuName = "Levels/Create Level", order = 2)]
public class Level : ScriptableObject
{
    [Tooltip("List of platforms to spawn.")]
    [SerializeField] private List<Platform> platformList;

    /// <summary>
    /// Get list containing the platforms.
    /// </summary>
    /// <returns>List of platforms for this level.</returns>
    public List<Platform> GetList()
    {
        return platformList;
    }
}

[Serializable]
public struct Platform
{
    [Tooltip("Prefab of the platform to spawn.")]
    public GameObject platformObject;
    [Tooltip("SpawnDistance of the next platform. This may vary if the prefab is longer or shorter than usual.")]
    public float spawnDistance;
}