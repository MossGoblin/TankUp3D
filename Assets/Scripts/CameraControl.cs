using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // refs
    [SerializeField] private Transform playerChasis;
    [SerializeField] private Transform playerTurret;
    public Camera camera;
    [SerializeField] public bool followChasis = true;

    [Range(0.01f, 1.0f)]
    [SerializeField] public float moveSmoothFactor = 0.5f;

    [Range(0.01f, 1.0f)]
    [SerializeField] public float rotateSmoothFactor = 0.5f;

    // [SerializeField] private Vector3 cameraOffset;
    [Range(0.0f, 100f)]
    [SerializeField] private float cameraHorizontalOffset;

    [Range(0.0f, 100f)]
    [SerializeField] private float cameraVerticalOffset;

    void Awake()
    {
        // camera = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        // Vector3 cameraOffset = playerChasis.transform.forward * -cameraHorizontalOffset + playerChasis.transform.up * cameraVerticalOffset;
        // Vector3 targetPosition = playerChasis.transform.position + cameraOffset;
        // transform.position = Vector3.Slerp(transform.position, targetPosition, moveSmoothFactor);

        if (followChasis)
        {
            AdjustRotation(playerChasis);
        }
        else
        {
            AdjustRotation(playerTurret);
        }
    }

    private void AdjustRotationToChasis()
    {
        Quaternion oldRotation = transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, playerChasis.rotation, rotateSmoothFactor);
    }

    private void AdjustRotationToTurret()
    {
        Quaternion oldRotation = transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, playerTurret.rotation, rotateSmoothFactor);
    }

    private void AdjustRotation(Transform anchor)
    {
        Vector3 cameraOffset = anchor.transform.forward * -cameraHorizontalOffset + anchor.transform.up * cameraVerticalOffset;
        Vector3 targetPosition = anchor.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, targetPosition, moveSmoothFactor);
        Quaternion oldRotation = transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, anchor.rotation, rotateSmoothFactor);
    }

}
