using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [Tooltip("Scriptable object containing the possible levels.")]
    [SerializeField] private LevelList levelList;

    private List<Platform> platforms;

    /// <summary>
    /// Get all the platforms for the current level and Spawn them.
    /// </summary>
    private void Awake()
    {
        Level level = GetCurrentLevel();

        platforms = level.GetList();
        SpawnPlatforms();
    }

    /// <summary>
    /// Spawn all the platforms at the right distance
    /// </summary>
    private void SpawnPlatforms()
    {
        if (platforms == null || platforms.Count <= 0)
            return;

        List<GameObject> platformObjects = new List<GameObject>();
        for (int index = 0; index < platforms.Count; index++)
        {
            Platform platform = platforms[index];
            GameObject platformObject = Instantiate(platform.platformObject, this.transform);
            platformObjects.Add(platformObject);

            if (index > 0)
            {
                GameObject previousPlatform = platformObjects[index - 1];
                float spawnDistance = platforms[index - 1].spawnDistance;
                float newZPos = previousPlatform.transform.localPosition.z + spawnDistance;
                platformObject.transform.localPosition += new Vector3(0, 0, newZPos);
            }
        }
    }

    /// <summary>
    /// Get the current level to load.
    /// If all the levels have been finished load the first level again.
    /// This is done because clearing player prefs in the editor is nice but in a build it is not.
    /// </summary>
    /// <returns></returns>
    private Level GetCurrentLevel()
    {
        if (levelList.levels == null || levelList.levels.Count <= 0)
        {
            Debug.LogError("No levels have been found!", this.gameObject);
            Destroy(this);
        }

        int index = PlayerPrefs.GetInt("LevelIndex");
        if (levelList.levels.Count <= index)
        {
            index = 0;
            PlayerPrefs.SetInt("LevelIndex", index);
        }

        return levelList.levels[index];
    }
}
