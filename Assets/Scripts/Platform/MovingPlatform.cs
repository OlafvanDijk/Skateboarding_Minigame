using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Tooltip("Movement speed of the platform")]
    [SerializeField] private float movementSpeed;
    [Tooltip("List of point to move the platform in between.")]
    [SerializeField] private List<Vector3> moveBetween;

    private int index;

    /// <summary>
    /// Moves the platform to the next available target.
    /// Destorys the script if there are no points to move between.
    /// </summary>
    void Update()
    {
        CheckList();

        if (index >= moveBetween.Count)
        {
            index = 0;
        }

        float step = movementSpeed * Time.deltaTime;
        Vector3 target = moveBetween[index];
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, step);

        if (Vector3.Distance(transform.localPosition, target) < 0.001f)
        {
            index++;
        }
    }

    /// <summary>
    /// Checks list for null value or entries.
    /// Destroys the movement script if condidtions are met to avoid unnecessary calls.
    /// </summary>
    private void CheckList()
    {
        if (moveBetween == null || moveBetween.Count <= 0)
        {
            Debug.LogError("No points to move between. Destroying Platform Movement script", this.gameObject);
            Destroy(this);
        }
    }
}
