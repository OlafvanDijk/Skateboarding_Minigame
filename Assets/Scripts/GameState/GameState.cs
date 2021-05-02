using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameState : MonoBehaviour
{
    [Header("Game")]
    [Tooltip("Delay before starting in seconds.")]
    [SerializeField] private float startDelay = 1f;

    [Header("Events")]
    public UnityEvent StartGame;
    public UnityEvent Finish;
    public UnityEvent GameOver;

    /// <summary>
    /// Start after a Delay.
    /// </summary>
    private void Start()
    {
        StartCoroutine(DelayedStart());
    }

    /// <summary>
    /// Set move to true after a delay.
    /// </summary>
    /// <returns></returns>
    private IEnumerator DelayedStart()
    {
        yield return new WaitForSecondsRealtime(startDelay);
        StartGame.Invoke();
    }
}
