using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class CameraPlayerMove : MonoBehaviour
{
    [SerializeField]
    private Transform _testPosition;
    [SerializeField]
    private float _speed = 2;
    [SerializeField]
    private Rigidbody _rigidbody;

    private Vector3 _currentCameraPosition;
    public Vector3 CurrentCameraPosition => _currentCameraPosition;
    public void SetCameraPosition(Vector3 pos) { _currentCameraPosition = pos; }

    private void Update()
    {
        if (_rigidbody != null)
        {
            _rigidbody.velocity = _dir * _speed;
        }
    }

    private Vector3 _dir;
    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("OnMove");
        Vector3 value = context.ReadValue<Vector2>();
        _dir = new Vector3(value.x, 0, value.y);

        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        _dir = cameraForward * _dir.z + Camera.main.transform.right * _dir.x;
    }
}
