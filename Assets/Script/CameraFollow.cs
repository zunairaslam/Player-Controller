using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    public Transform targetTransform;
    public Transform cameraTransform;
    public Transform cameraPivotTransform;
    private Transform playerTransform;
    private Vector3 cameraTransformPosition;
    private LayerMask ignoreLayers;

    public static CameraFollow instance;

    public float lookSpeed = 0.1f;
    public float followSpeed = 0.1f;
    public float pivotSpeed = 0.03f;

    private float defaultPosition;
    private float lookAngle;
    private float pivotAngle;
    public float minimPivot = -35f;
    public float maxPivot = 35f;

    private void Awake()
    {
        instance = this; 
        playerTransform= transform;
        defaultPosition = cameraTransform.localPosition.z;
        ignoreLayers = ~(1 << 8 | 1 << 9 | 1<< 10);
    }
    public void FollowTarget(float delta)
    {
        Vector3 targetPosition = Vector3.Lerp(playerTransform.position, targetTransform.position, delta / followSpeed);
        playerTransform.position = targetPosition;
    }

    public void HandlerCmaeraRotation(float delta, float mouseXInput, float mouseYInput)
    {
        lookAngle += (mouseXInput * lookSpeed) / delta;
        pivotAngle-= (mouseYInput * pivotSpeed) / delta;
        pivotAngle = Mathf.Clamp(pivotAngle, minimPivot, maxPivot);

        Vector3 rotation = Vector3.zero;
        rotation.y = lookAngle;
        Quaternion targetRotation = Quaternion.Euler(rotation);
        playerTransform.rotation = targetRotation;

        rotation = Vector3.zero;
        rotation.x = pivotAngle;

        targetRotation= Quaternion.Euler(rotation);
        cameraPivotTransform.localRotation= targetRotation; 
    }
}
