using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject finishUI;
    [SerializeField] private GameObject nextLevelButton;

    /// <summary>
    /// Show Finish UI and select the next level button.
    /// Selecting a button in the event system is for UI Controll with a controller.
    /// </summary>
    public void OnFinish()
    {
        finishUI.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(nextLevelButton);
    }

    /// <summary>
    /// Update Level Index and Reload the Scene.
    /// </summary>
    public void NextLevel()
    {
        int index = PlayerPrefs.GetInt("LevelIndex") + 1;
        PlayerPrefs.SetInt("LevelIndex", index);
        SceneManager.LoadScene(0);
    }
}
