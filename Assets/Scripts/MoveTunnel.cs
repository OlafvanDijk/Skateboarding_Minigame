using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTunnel : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0), Space.Self);
    }
}
