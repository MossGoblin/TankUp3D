using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFollowMouse : MonoBehaviour
{
    // refs
    [SerializeField]
    private GameMaster master;
    private Vector3 rotationTargetPosition;

    [Range(0.0f, 5.0f)]
    [SerializeField] float turretRotationSpeed = 2f; // TODO : Magic Number! Should be taken from a player data pool

    private int movementLayer = 8;
    [SerializeField]
     private GameObject targetPrefab;

    private GameObject turret;
    private Vector3 targetPosition;
    private Quaternion targetRotation;

    private Camera camera;
    
    void Awake()
    {
        turret = this.gameObject;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 mousePosition = new Vector3();
        RaycastHit mousePositionHit = master.mouseMaster.GetRayHitMouse();
        mousePosition = mousePositionHit.transform.position;
        float mousePosition_x = mousePositionHit.point.x;
        float mousePosition_z = mousePositionHit.point.z;
        float mousePosition_y = this.transform.position.y;
        Vector3 targetPosition = new Vector3(mousePosition_x, mousePosition_y, mousePosition_z);
        Vector3 targetDirection = targetPosition - transform.position;
        float singleStep = turretRotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        Debug.DrawRay(transform.position, newDirection*20, Color.red);
        transform.rotation = Quaternion.LookRotation(newDirection);
        // Debug.Log("Direction " + newDirection);
        // // create a dummy at the target position
        

        // turret.transform.LookAt(targetPosition);
        // Debug.Log(mousePosition);
    }
}
