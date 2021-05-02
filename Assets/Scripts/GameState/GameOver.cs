using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject retryButton;

    /// <summary>
    /// Show GameOver UI and select the next level button.
    /// Selecting a button in the event system is for UI Controll with a controller.
    /// </summary>
    public void OnGameOver()
    {
        gameOverUI.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(retryButton);
    }

    /// <summary>
    /// Reload the Scene.
    /// </summary>
    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
}
