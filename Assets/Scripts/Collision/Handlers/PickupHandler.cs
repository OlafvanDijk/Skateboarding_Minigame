using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupHandler : CollisionHandler
{
    [Header("UI")]
    [Tooltip("Text displaying the current Points.")]
    [SerializeField] private TextMeshProUGUI overlayPointText;
    [Tooltip("Text displaying the level Points.")]
    [SerializeField] private TextMeshProUGUI finishPointText;

    private int currentPoints;

    /// <summary>
    /// Pickup given object.
    /// </summary>
    /// <param name="pickupObject">Object of Collision.</param>
    public override void HandleOnCollisionEnter(GameObject pickupObject)
    {
        Pickup(pickupObject);
    }

    /// <summary>
    /// Pickup given object.
    /// </summary>
    /// <param name="pickupObject">Object of Collision.</param>
    public override void HandleOnTriggerEnter(GameObject pickupObject)
    {
        Pickup(pickupObject);
    }

    public void OnFinish()
    {
        finishPointText.text = $"Score: {currentPoints}";
    }

    /// <summary>
    /// HIde Pickup Object and add it's point to the current score
    /// </summary>
    /// <param name="pickupObject">Object to Pick Up</param>
    private void Pickup(GameObject pickupObject)
    {
        pickupObject.SetActive(false);
        Pickup pickup = pickupObject.GetComponent<Pickup>();
        currentPoints += pickup.points;
        overlayPointText.text = currentPoints.ToString();
    }
}
