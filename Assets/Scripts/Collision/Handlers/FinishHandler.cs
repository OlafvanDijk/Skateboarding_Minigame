using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishHandler : CollisionHandler
{
    [Tooltip("Refference to the GameState script so we can Invoke the Finish Event.")]
    [SerializeField] private GameState gameState;

    public override void HandleOnCollisionEnter(GameObject gameObject)
    {
        OnFinish();
    }

    public override void HandleOnTriggerEnter(GameObject gameObject)
    {
        OnFinish();
    }

    /// <summary>
    /// Invoke the Finish Event.
    /// </summary>
    private void OnFinish()
    {
        gameState.Finish.Invoke();
    }
}
