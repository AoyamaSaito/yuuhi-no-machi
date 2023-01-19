using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;
using UnityEngine.InputSystem;
using System.Threading;
using System.Threading.Tasks;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour, IPause
{
    [SerializeField]
    private float _speed = 2;
    [SerializeField]
    private Rigidbody _rigidbody;
    [Header("Test")]
    [SerializeField]
    private bool _isMove = true;
    [SerializeField]
    private Transform _testPosition;

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
    /// <summary>
    /// プレイヤーの移動を行うクラス
    /// InputSystemから呼ぶ
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        if(_isMove == false) return;

        Vector3 value = context.ReadValue<Vector2>();
        _dir = new Vector3(value.x, 0, value.y);

        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        _dir = cameraForward * _dir.z + Camera.main.transform.right * _dir.x;
    }

    public void Pause()
    {
        if (_rigidbody != null)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularDrag = 0;

            _isMove = false;
        }
    }

    public void Resume()
    {
        _isMove = true;
    }

}
