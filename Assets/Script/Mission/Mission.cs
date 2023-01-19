using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Mission�Ɋւ��鏈�����s��
/// ��{�I�ɂ�Message������Ăяo�����z��
/// </summary>
public class Mission : MonoBehaviour
{
    [Header("�Ή������~�b�V�����f�[�^���A�^�b�`����")]
    [SerializeField]
    private MissionData _missionData;

    [Space(15f)]
    [Header("�~�b�V�������X�^�[�g������ꍇ�͗L���ɂ���")]
    [SerializeField]
    private bool _isStartMission = false;
    [Header("�~�b�V�������N���A������ꍇ�ɂ͗L���ɂ���")]
    [SerializeField]
    private bool _isClearMission = false;

    /// <summary>
    /// Mission���X�^�[�g����֐�
    /// ��{�I�ɂ�MessageInteract����Ăяo�����z��
    /// </summary>
    public void StartMission()
    {
        MissionManager.Instance.StartMission(_missionData);
    }

    /// <summary>
    /// Mission���N���A����֐�
    /// ��{�I�ɂ�MessageInteract����Ăяo�����z��
    /// </summary>
    public void ClearMission()
    {
        MissionManager.Instance.ClearMission(_missionData);
    }
}
