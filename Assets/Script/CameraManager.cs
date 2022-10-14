using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class CameraManager
{
    static private CameraManager _instance = new CameraManager();
    static public CameraManager Instance => _instance;
    private CameraManager() { }

    private CinemachineVirtualCamera _currentVirtualCamera;
    public CinemachineVirtualCamera VirtualCamera => _currentVirtualCamera;
    public void SetCurrentCamera(CinemachineVirtualCamera vCam) { _currentVirtualCamera = vCam; }

    private CameraPlayerMove _cameraMove;
    public CameraPlayerMove CameraMove => _cameraMove;
    public void SetPlayer(CameraPlayerMove cpm) { _cameraMove = cpm; }
}

