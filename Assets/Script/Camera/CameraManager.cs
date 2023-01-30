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

    private PlayerMove _cameraMove;
    public PlayerMove CameraMove => _cameraMove;

    public void SetCurrentCamera<T>(T cameraChanger) where T : ICameraChanger
    {
        cameraChanger.VCam.MoveToTopOfPrioritySubqueue();
        _currentVirtualCamera = cameraChanger.VCam;
    }

    public void SetPlayer(PlayerMove cpm) { _cameraMove = cpm; }
}

