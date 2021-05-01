using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollisionHandler : MonoBehaviour
{
    public abstract void HandleOnTriggerEnter(GameObject gameObject);
    public abstract void HandleOnCollisionEnter(GameObject gameObject);
}
