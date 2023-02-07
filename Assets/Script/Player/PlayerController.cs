using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerMove _playerMove;
    [SerializeField]
    private PlayerInteract _playerInteract;
    [SerializeField]
    private PlayerView _playerView;

    private void Update()
    {
        _playerView.MoveAnimationSwitch(_playerMove.Rigidbody.velocity.magnitude);
    }
}