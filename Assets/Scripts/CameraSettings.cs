using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    public float smoothSpeed = 0.1f;

    private void LateUpdate()
    {
        if (playerTransform != null)
        {
            SmoothFollow();
        }
    }

    public void SmoothFollow()
    {
        Vector3 targetPos = playerTransform.position + offset;
        Vector3 smoothFollow = Vector3.Lerp(transform.position,
            targetPos, smoothSpeed);

        transform.position = smoothFollow;
        transform.LookAt(playerTransform);
    }
    void Update()
    {
        if (playerTransform != null)
        {
            gameObject.transform.position = new Vector3(
                playerTransform.position.x,
                playerTransform.position.y,
                -5
                );
        }
    }
}
