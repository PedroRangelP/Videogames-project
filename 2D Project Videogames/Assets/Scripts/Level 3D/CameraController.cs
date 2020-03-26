﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private Transform follow;

    [Header("Settings")]
    [SerializeField] private Vector3 offset = new Vector3(0, 10, -10);
    [SerializeField] private Vector3 minPosition = new Vector3(0, 0, 0);
    [SerializeField] private Vector3 maxPosition = new Vector3(0, 0, 0);

    [Header("Smooth")]
    [SerializeField] private bool enableSmooth = true;
    [SerializeField] private float smoothSpeed = 3f;
    private Vector3 desiredPosition;

    private void LateUpdate()
    {
        float x = Mathf.Clamp(follow.position.x, minPosition.x, maxPosition.x);
        float y = Mathf.Clamp(follow.position.y, minPosition.y, maxPosition.y);
        float z = Mathf.Clamp(follow.position.z, minPosition.z, maxPosition.z);

        desiredPosition = new Vector3(x,y,z) + offset;

        if (enableSmooth)
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
        else
            transform.position = desiredPosition;
    }

    /*public GameObject follow;
    private Vector3 velocity;
    [SerializeField] private Vector3 minPos, maxPos;
    [SerializeField] private float smoothTime;
    
    void FixedUpdate()
    {
        float x = Mathf.SmoothDamp(transform.position.x,
            follow.transform.position.x,
            ref velocity.x,
            smoothTime);
        float z = Mathf.SmoothDamp(transform.position.z,
            follow.transform.position.z,
            ref velocity.z,
            smoothTime);

        transform.position = new Vector3(
            Mathf.Clamp(x, minPos.x, maxPos.x),
            transform.position.y,
            Mathf.Clamp(z, minPos.z, maxPos.z));
    }*/
}
