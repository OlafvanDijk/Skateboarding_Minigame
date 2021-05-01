using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CollisionRegistrator : MonoBehaviour
{
    [SerializeField] List<Handler> collisionHandlers;

    /// <summary>
    /// If a handler with the collision's tag exists call the HandleOnTriggerEnter function
    /// </summary>
    /// <param name="collision">Object of Collision</param>
    private void OnTriggerEnter(Collider other)
    {
        CollisionHandler handler = FindHandler(other.tag);
        if (handler != null)
        {
            handler.HandleOnTriggerEnter(other.gameObject);
        }
    }

    /// <summary>
    /// If a handler with the collision's tag exists call the HandleOnCollisionEnter function
    /// </summary>
    /// <param name="collision">Object of Collision</param>
    private void OnCollisionEnter(Collision collision)
    {
        CollisionHandler handler = FindHandler(collision.gameObject.tag);
        if (handler != null)
        {
            handler.HandleOnCollisionEnter(collision.gameObject);
        }
    }

    /// <summary>
    /// Find and return the corresponding handler.
    /// </summary>
    /// <param name="tag">Tag of the object of collision.</param>
    /// <returns>Handler that corresponds with the given tag.</returns>
    private CollisionHandler FindHandler(string tag)
    {
        if (collisionHandlers.Count > 0)
        {
            try
            {
                return collisionHandlers.Find(handler => handler.tag.Equals(tag)).collisionHandler;
            }
            catch (Exception)
            {
                return null;
            }
        }
        return null;
    }
}

[Serializable]
public struct Handler
{
    public string tag;
    public CollisionHandler collisionHandler;
}