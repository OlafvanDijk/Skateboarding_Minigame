using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHandler : CollisionHandler
{
    [Tooltip("Refference to the GameState script so we can Invoke the GameOver Event.")]
    [SerializeField] private GameState gameState;

    public override void HandleOnCollisionEnter(GameObject gameObject)
    {
        OnGameOver();
    }

    public override void HandleOnTriggerEnter(GameObject gameObject)
    {
        OnGameOver();
    }

    /// <summary>
    /// Invoke the GameOver Event.
    /// </summary>
    private void OnGameOver()
    {
        gameState.GameOver.Invoke();
    }
}
