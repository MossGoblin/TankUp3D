using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    // refs
    [SerializeField] private Turret turret;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 turretPosition = turret.transform.position;
        Quaternion turretRotation = turret.transform.rotation;
        Vector3 newPosition = turret.transform.forward * 20;
        Quaternion newRotation = turretRotation;
        this.transform.position = newPosition;
        this.transform.rotation = newRotation;
    }
}
