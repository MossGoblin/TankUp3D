using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFollowMouse : MonoBehaviour
{
    // refs
    [SerializeField] private Camera camera;
    private Vector3 rotationTargetPosition;

    [Range(0.0f, 5.0f)]
    [SerializeField] float turretRotationSpeed = 2f; // TODO : Magic Number! Should be taken from a player data pool

    private int movementLayer = 8;

    private GameObject turret;
    private Vector3 targetPosition;
    private Quaternion targetRotation;
    
    void Awake()
    {
        turret = this.gameObject;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Version 1
        // RaycastHit mouseRay;
        // if(Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out mouseRay, Mathf.Infinity, movementLayer))
        // {
        //     targetPosition = mouseRay.point;
        //     targetRotation = Quaternion.LookRotation(transform.position - targetPosition);
        // }


        // // mouseWorldPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        // Debug.Log(targetPosition);
        // turret.transform.rotation = targetRotation;

        // Version 2
        // float newRotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X");
        // float newRotationX = transform.localEulerAngles.x - Input.GetAxis("Mouse Y");
        // turret.transform.localEulerAngles = new Vector3(newRotationX, newRotationY, 0);

        // Version 3
        // cast a ray from the mouse
        // turn the turret towards the position

        // raycast from the screen/mouse


        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit mousePositionHit;
        Vector3 mousePosition = new Vector3();
        if(Physics.Raycast(ray, out mousePositionHit))
        {
            mousePosition = mousePositionHit.transform.position;
            Debug.Log(mousePositionHit.transform.gameObject.name + " / " + mousePositionHit.transform.position);
        }
        float mousePosition_x = mousePositionHit.point.x;
        float mousePosition_z = mousePositionHit.point.z;
        float mousePosition_y = this.transform.position.y;
        Vector3 targetPosition = new Vector3(mousePosition_x, mousePosition_y, mousePosition_z);
        Vector3 targetDirection = targetPosition - transform.position;
        float singleStep = turretRotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        Debug.DrawRay(transform.position, newDirection*20, Color.red);
        transform.rotation = Quaternion.LookRotation(newDirection);
        Debug.Log("Direction " + newDirection);
        // // create a dummy at the target position
        // Instantiate(new GameObject(), targetPosition, Quaternion.identity, this.transform);
        

        // turret.transform.LookAt(targetPosition);
        // Debug.Log(mousePosition);
    }
}
