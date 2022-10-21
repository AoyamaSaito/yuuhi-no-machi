using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField, Tooltip("�C���^���N�g�\���ǂ����̃t���O")]
    private bool isInteract = false;

    private IInteracted _interacted;

    /// <summary>
    /// InputSystem�ŌĂяo���AA�{�^���ŃC���^���N�g���s���֐�
    /// </summary>
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && _interacted != null)
        {
            _interacted.Interact();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteracted interacted))
        {
            Debug.Log("Enter");
            Debug.Log(_interacted);
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
