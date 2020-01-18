using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFollowMouse : MonoBehaviour
{
    // refs
    [SerializeField]
    private GameMaster master;
    private InputController inputMaster;
    private Vector3 rotationTargetPosition;
    private Tank tank;

    [Range(0.0f, 5.0f)]
    [SerializeField] float baseTurretRotationSpeed = 2f; // TODO : Magic Number! Should be taken from a player data pool
    [SerializeField] float currentTurretRotationSpeed; // TODO : Magic Number! Should be taken from a player data pool

    private int movementLayer = 8;
    [SerializeField]
     private GameObject targetPrefab;

    private GameObject turret;
    private Vector3 targetPosition;
    private Quaternion targetRotation;

    private Camera camera;
    
    void Awake()
    {
        inputMaster = master.inputMaster;
        turret = this.gameObject;
        tank = master.player.tank;
        currentTurretRotationSpeed = baseTurretRotationSpeed;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        currentTurretRotationSpeed = baseTurretRotationSpeed - tank.rotationSpeedFactor * 0.05f;
        Vector3 mousePosition = new Vector3();
        RaycastHit mousePositionHit = inputMaster.GetRayHitMouse();
        mousePosition = mousePositionHit.transform.position;
        float mousePosition_x = mousePositionHit.point.x;
        float mousePosition_z = mousePositionHit.point.z;
        float mousePosition_y = this.transform.position.y;
        Vector3 targetPosition = new Vector3(mousePosition_x, mousePosition_y, mousePosition_z);
        Vector3 targetDirection = targetPosition - transform.position;
        float singleStep = currentTurretRotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        Debug.DrawRay(transform.position, newDirection*20, Color.red);
        
        transform.rotation = Quaternion.LookRotation(newDirection);
        // Debug.Log("Direction " + newDirection);
        // // create a dummy at the target position
        

        // turret.transform.LookAt(targetPosition);
        // Debug.Log(mousePosition);
    }
}
