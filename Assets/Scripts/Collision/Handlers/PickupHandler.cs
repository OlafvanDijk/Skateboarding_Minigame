using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickupHandler : CollisionHandler
{
    [SerializeField] private TextMeshProUGUI pointText;

    private int currentPoints;

    public override void HandleOnCollisionEnter(GameObject collisionObject)
    {
        Pickup(collisionObject);
    }

    public override void HandleOnTriggerEnter(GameObject collisionObject)
    {
        Pickup(collisionObject);
    }

    private void Pickup(GameObject collisionObject)
    {
        Debug.Log("picked up", gameObject);
        collisionObject.SetActive(false);
        Pickup pickup = collisionObject.GetComponent<Pickup>();
        currentPoints += pickup.points;
        pointText.text = currentPoints.ToString();
    }
}
