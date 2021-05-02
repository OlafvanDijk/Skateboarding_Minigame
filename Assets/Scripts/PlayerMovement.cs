using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Speed")]
    [Tooltip("Horizontal Movement Speed of the Player.")]
    [SerializeField] private float horizontalSpeed;
    [Tooltip("Forward Movement Speed of the Player.")]
    [SerializeField] private float verticalSpeed;
    [Tooltip("Maximum amount of Velocity on the Z axis")]
    [SerializeField] float maximumSpeed;
    [Tooltip("Maximum Velocity that will be counted as falling. The higher this number the earlier the player will start to fall during a jump.")]
    [SerializeField] float fallVelocity;

    [Header("Animations")]
    [Tooltip("Reference to the Animator of the Player.")]
    [SerializeField] private Animator animator;

    [Header("Jumping")]
    [Tooltip("How much Force should be used to Jump.")]
    [SerializeField] private float jumpForce;
    [Tooltip("How much faster should we go Down from a Jump.")]
    [Min(1.1f)]
    [SerializeField] private float fallMultiplier;

    [Header("Ducking")]
    [Tooltip("Collider of the player while standing.")]
    [SerializeField] private Collider standingCollider;
    [Tooltip("Collider of the player while ducking.")]
    [SerializeField] private Collider duckingCollider;

    private Rigidbody playerRigidbody;

    private float rawInputX;

    private bool move = false;
    private bool isJumping = false;
    private bool allowedToJump = true;

    #region Unity Methods
    /// <summary>
    /// Get Rigidbody Component.
    /// </summary>
    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Moves the player forward and horizontally
    /// Also quickens the fall during a jump
    /// </summary>
    private void FixedUpdate()
    {
        if (move)
        {
            if (isJumping)
            {
                if (playerRigidbody.velocity.y < fallVelocity)
                {
                    playerRigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
                }
            }

            float vertical = verticalSpeed * Time.fixedDeltaTime;
            float horizontal = rawInputX * (horizontalSpeed * 100) * Time.fixedDeltaTime;

            playerRigidbody.AddForce(new Vector3(horizontal, 0, 0), ForceMode.Force);

            transform.Translate(new Vector3(0, 0, vertical));
        }
    }
    #endregion

    #region Public Methods

    #region InputAction Methods
    /// <summary>
    /// Input Method that gets called when a new value is being sent by the InputSystem
    /// </summary>
    /// <param name="value">Vector 2 value containing the Movement Axis.</param>
    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        rawInputX = inputMovement.x;
    }

    /// <summary>
    /// Input Method that gets called when the player presses the Jump button.
    /// Adds force to the ridigbody and changes the boolean isJumping to true.
    /// </summary>
    /// <param name="value">Object containing Callback Context</param>
    public void OnPressJump(InputAction.CallbackContext value)
    {
        if (move && allowedToJump && value.started && !isJumping)
        {
            playerRigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isJumping = true;
        }
    }

    /// <summary>
    /// Let the player duck when the Duck Button is held down and stand when the button is no longer being held down.
    /// </summary>
    /// <param name="value">Object containing Callback Context</param>
    public void OnPressDuck(InputAction.CallbackContext value)
    {
        if (move)
        {
            if (value.performed)
            {
                SetDuckingParams(true);
            }
            else if (value.canceled)
            {
                SetDuckingParams(false);
            }
        }
    }
    #endregion

    /// <summary>
    /// Set the isJumping boolean. This method is currently used by the GroundHandler
    /// </summary>
    /// <param name="isJumping">Is the player currently in a jump.</param>
    public void SetIsJumping(bool isJumping)
    {
        this.isJumping = isJumping;
    }

    /// <summary>
    /// Set the move boolean to the given boolean.
    /// Changes if the player can move or not
    /// </summary>
    /// <param name="canMove">Should the player be able to move</param>
    public void CanPlayerMove(bool canMove)
    {
        move = canMove;
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Let the player duck or stand based on the given value.
    /// Set animator bool, colliders and if the player is allowed to jump.
    /// </summary>
    /// <param name="ducking">Should the player duck or stand.</param>
    private void SetDuckingParams(bool ducking)
    {
        animator.SetBool("Ducking", ducking);
        duckingCollider.enabled = ducking;

        standingCollider.enabled = !ducking;
        allowedToJump = !ducking;
    }
    #endregion
}
