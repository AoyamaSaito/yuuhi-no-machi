using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

[RequireComponent(typeof(BoxCollider))]
public class CameraChanger : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera _vCam;

    [Header("Å‰‚É—LŒø‰»‚µ‚Ä‚¨‚­ƒJƒƒ‰")]
    [SerializeField]
    private bool _defaultCamera = false;

    private CameraManager _cameraManager;

    private void Start()
    {
        _cameraManager = CameraManager.Instance;

        if(_defaultCamera == true)
        {
            SetCurrentCamera();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_vCam != null)
        {
            SetCurrentCamera();
        }
    }

    private void SetCurrentCamera()
    {
        _cameraManager?.SetCurrentCamera(_vCam);
    }
}
