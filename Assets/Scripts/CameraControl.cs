using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // refs
    [SerializeField] private Transform player;

    [Range(0.01f, 1.0f)]
    [SerializeField] public float moveSmoothFactor = 0.5f;

    [Range(0.01f, 1.0f)]
    [SerializeField] public float rotateSmoothFactor = 0.5f;

    // [SerializeField] private Vector3 cameraOffset;
    [SerializeField] private float cameraHorizontalOffset;
    [SerializeField] private float cameraVerticalOffset;

    void Start()
    {
    }

    void LateUpdate()
    {
        Vector3 cameraOffset = player.transform.forward * -cameraHorizontalOffset + player.transform.up * cameraVerticalOffset;
        Vector3 targetPosition = player.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, targetPosition, moveSmoothFactor);
        Quaternion oldRotation = transform.rotation;

        // transform.localRotation = player.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, rotateSmoothFactor);
    }
}
