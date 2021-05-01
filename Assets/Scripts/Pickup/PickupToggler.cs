using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupToggler : MonoBehaviour
{
    [Tooltip("List of parent objects of the pickups.")]
    [SerializeField] private List<GameObject> pickups;

    /// <summary>
    /// Pick one of the pickup Gameobjects to enable
    /// Deletes the script if there are none.
    /// </summary>
    void Awake()
    {
        CheckAvailablePickups();

        int index = 0;
        if (pickups.Count > 1)
        {
            index = Random.Range(0, pickups.Count);
        }

        pickups[index].SetActive(true);
    }

    /// <summary>
    /// Check for pickups in the list.
    /// If there are none delete this script.
    /// </summary>
    private void CheckAvailablePickups()
    {
        if (pickups.Count < 0)
        {
            Debug.Log("No pickups in this platform group.", gameObject);
            Destroy(this);
        }
    }
}
