using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    //TODO Replace this with a level list and level index PlayerPref
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
        for (int i = 0; i < platforms.Count; i++)
        {
            Platform platform = platforms[i];
            GameObject platformObject = Instantiate(platform.platformObject, this.transform);
            platformObjects.Add(platformObject);

            if (i > 0)
            {
                GameObject previousPlatform = platformObjects[i - 1];
                float spawnDistance = platforms[i - 1].spawnDistance;
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
        }

        return levelList.levels[index];
    }
}
