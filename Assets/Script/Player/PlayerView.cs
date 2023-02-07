using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private string _animatorSpeedTag = "Speed";

    public void MoveAnimationSwitch(float speed)
    {
        if (_animator == null)
        {
            Debug.Log("Animator‚ªnull‚Å‚·");
            return;
        }

        _animator.SetFloat(_animatorSpeedTag, speed);
    }
}
