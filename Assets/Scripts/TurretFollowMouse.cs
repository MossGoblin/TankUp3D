using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFollowMouse : MonoBehaviour
{
    // refs
    [SerializeField] private Camera camera;
    private Vector3 rotationTargetPosition;
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
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit mousePositionHit;
        Vector3 mousePosition = new Vector3();
        if(Physics.Raycast(ray, out mousePositionHit))
        {
            mousePosition = mousePositionHit.transform.position;
        }
        turret.transform.LookAt(mousePosition);
        Debug.Log(mousePosition);
    }
}
