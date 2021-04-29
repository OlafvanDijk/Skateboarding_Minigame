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

    [Header("Jumping")]
    [Tooltip("How much Force should be used to Jump.")]
    [SerializeField] private float jumpForce;
    [Tooltip("How much faster should we go Down from a Jump.")]
    [Min(1.1f)]
    [SerializeField] private float fallMultiplier;

    private Rigidbody playerRigidbody;

    private bool move = false;
    private bool isJumping = false;
    private float rawInputX;

    #region Unity Methods
    /// <summary>
    /// Get Rigidbody Component.
    /// </summary>
    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Start moving after a small delay.
    /// </summary>
    private void Start()
    {
        StartCoroutine(DelayedStart());
    }

    /// <summary>
    /// Moves the player forward and horizontally
    /// Also quickens the fall during a jump
    /// </summary>
    void FixedUpdate()
    {
        if (move)
        {
            if (isJumping)
            {
                if (playerRigidbody.velocity.y < 0)
                {
                    playerRigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
                }
            }

            float vertical = verticalSpeed * Time.deltaTime;
            float horizontal = rawInputX * horizontalSpeed * Time.deltaTime;
            transform.Translate(new Vector3(horizontal, 0, vertical));
        }
    }

    /// <summary>
    /// Stop jumping and set the rotaion of the player to equal the collision object when colliding with a ground object.
    /// </summary>
    /// <param name="collision">Object of collision.</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            Vector3 rotation = collision.transform.rotation.eulerAngles;
            playerRigidbody.rotation = Quaternion.Euler(rotation.x, playerRigidbody.rotation.y, playerRigidbody.rotation.z);
        }
    }
    #endregion

    #region Public Methods
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
        if (move && value.started && !isJumping)
        {
            playerRigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isJumping = true;
        }
    }
    #endregion

    #region IEnumerators
    /// <summary>
    /// Set move to true after a delay.
    /// </summary>
    /// <returns></returns>
    private IEnumerator DelayedStart()
    {
        yield return new WaitForSecondsRealtime(1f);
        move = true;
    }
    #endregion
}
