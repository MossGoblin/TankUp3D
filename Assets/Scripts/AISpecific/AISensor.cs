using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scans the surroundings of the AITank (on Update) for interactble objects
/// Performs self-assessment ??
/// </summary>
public class AISensor : MonoBehaviour
{
    // refs
    [SerializeField] float sensorRadius;
    public List<GameObject> objectsInRange { get; private set; }

    void FixedUpdate()
    {
        objectsInRange = ObjectsInRange();
        ReportOnObjectsInRange(objectsInRange);
    }

    private void ReportOnObjectsInRange(List<GameObject> objectsInRange) // FIXME : Debug Only
    {
        foreach (var obj in objectsInRange)
        {
            if (obj.gameObject.layer == 9 && obj != this)
            {
                Debug.Log($"{obj.gameObject.name} in range");
            }
        }
    }

    private List<GameObject> ObjectsInRange()
    {
        List<GameObject> objectsInRange = new List<GameObject>();
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, sensorRadius);
        foreach (var collider in hitColliders)
        {
            if (collider.gameObject.layer == 9 && collider != this)
            {
                objectsInRange.Add(collider.gameObject);
            }
        }
        return objectsInRange;
    }
}
