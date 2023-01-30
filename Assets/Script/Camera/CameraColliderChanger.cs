using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

[RequireComponent(typeof(BoxCollider))]
public class CameraColliderChanger : MonoBehaviour, ICameraChanger
{
    [SerializeField]
    private CinemachineVirtualCamera _vCam;

    [Header("Å‰‚É—LŒø‰»‚µ‚Ä‚¨‚­ƒJƒƒ‰")]
    [SerializeField]
    private bool _defaultCamera = false;

    private CameraManager _cameraManager;

    public CinemachineVirtualCamera VCam => _vCam; 

    private void Start()
    {
        _cameraManager = CameraManager.Instance;

        if(_defaultCamera == true)
        {
            CameraChange();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_vCam != null)
        {
            CameraChange();
        }
    }

    public void CameraChange()
    {
        _cameraManager.SetCurrentCamera(this);
    }
}
