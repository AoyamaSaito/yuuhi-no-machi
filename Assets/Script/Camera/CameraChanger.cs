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
    [SerializeField]
    private bool _isFirst = false;

    private CameraManager _cameraManager;

    private void Start()
    {
        _cameraManager = CameraManager.Instance;

        if(_isFirst == true)
        {
            SetThisCamera();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_vCam != null)
        {
            SetThisCamera();
        }
    }

    private void SetThisCamera()
    {
        _vCam.MoveToTopOfPrioritySubqueue();
        _cameraManager?.SetCurrentCamera(_vCam);
    }
}
