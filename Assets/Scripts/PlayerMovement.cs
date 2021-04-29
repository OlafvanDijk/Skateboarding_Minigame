using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody playerRigidboy;

    private void Awake()
    {
        playerRigidboy = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 force = new Vector3(GetSpeed(horizontal), 0, GetSpeed(vertical));
        playerRigidboy.AddForce(force, ForceMode.Acceleration);
    }

    private float GetSpeed(float input)
    {
        return input * speed * 10;
    }
}
