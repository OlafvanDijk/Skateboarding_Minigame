using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTunnel : MonoBehaviour
{
    [Tooltip("Speed of the Rotation of the Tunnel.")]
    [SerializeField] private float rotationSpeed;

    private bool move = true;

    /// <summary>
    /// Rotate Tunnel if move is true
    /// </summary>
    private void Update()
    {
        if(move)
            transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
    }

    /// <summary>
    /// Set the move boolean to the given boolean.
    /// Changes if the Tunnel can move or not
    /// </summary>
    /// <param name="canMove">Should the player be able to move</param>
    public void CanTunnelMove(bool canMove)
    {
        move = canMove;
    }
}
