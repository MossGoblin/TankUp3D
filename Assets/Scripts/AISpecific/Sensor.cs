using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sensor : MonoBehaviour
{
    // refs
    [SerializeField] float sensorRadius;
    public List<GameObject> objectsInRange { get; private set; }

    private void Awake()
    {
        objectsInRange = ObjectsInRange();
    }
    void FixedUpdate()
    {
        objectsInRange = ObjectsInRange();
        ReportObjectsInRange(objectsInRange);
    }

    public List<GameObject> Ping()
    {
        return ObjectsInRange();
    }

    private void ReportObjectsInRange(List<GameObject> objectsInRange) // FIXME : Debug Only
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
