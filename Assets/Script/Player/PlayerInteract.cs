using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private IInteracted _interacted;

    /// <summary>
    /// InputSystem�ŌĂяo��
    /// A�{�^���ŃC���^���N�g���s���֐�
    /// </summary>
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && _interacted != null)
        {
            _interacted.Interact();
        }
    }

    /// <summary>
    /// �R���C�_�[�ɐG���ƁAIInteracted��_interacted�ɓ����
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteracted interacted))
        {
            Debug.Log("Enter");
            Debug.Log(interacted);
            _interacted = interacted;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IInteracted>(out _))
        {
            _interacted.Exit();
            _interacted = null;
        }
    }
}
