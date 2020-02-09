using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scans the surroundings of the AITank (on Update) for interactble objects
/// Performs self-assessment
/// </summary>
public class AISensor : MonoBehaviour
{
    // refs
    [SerializeField] float sensorRadius;
    List<GameObject> objectsInRange;

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        objectsInRange = ObjectsInRange();
        ReportOnObjectsInRange(objectsInRange);
    }

    private void ReportOnObjectsInRange(List<GameObject> objectsInRange)
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

    // private void OnTriggerEnter(Collider other) {
    //     if (other.gameObject.layer == 9 && other != this)
    //     {
    //         Debug.Log($"Enter {other.gameObject.name}");
    //     }
    // }

    // private void OnTriggerStay(Collider other) {
    //     if (other.gameObject.layer == 9 && other != this)
    //     {
    //         Debug.Log($"{other.gameObject.name} in range");
    //     }
    // }

    /*
     Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].SendMessage("AddDamage");
            i++;
        }
    */
}
