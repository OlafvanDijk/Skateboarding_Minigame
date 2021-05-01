using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHandler : CollisionHandler
{
    [Tooltip("Rigidbody of the player.")]
    [SerializeField] private Rigidbody player;
    [Tooltip("PlayerMovement script to set the isJumping bool to false.")]
    [SerializeField] private PlayerMovement playerMovement;

    /// <summary>
    /// Rotate the Player.
    /// </summary>
    /// <param name="ground">Object of Collision.</param>
    public override void HandleOnCollisionEnter(GameObject ground)
    {
        RotatePlayer(ground);
    }

    /// <summary>
    /// Rotate the Player.
    /// </summary>
    /// <param name="ground">Object of Collision.</param>
    public override void HandleOnTriggerEnter(GameObject ground)
    {
        RotatePlayer(ground);
    }

    /// <summary>
    /// Rotate the player to match the ground's rotation
    /// </summary>
    /// <param name="ground">Object of Collision.</param>
    private void RotatePlayer(GameObject ground)
    {
        playerMovement.SetIsJumping(false);
        Vector3 rotation = ground.transform.rotation.eulerAngles;
        player.rotation = Quaternion.Euler(rotation.x, player.rotation.y, player.rotation.z);
    }
}
