using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Missionに関する処理を行う
/// 基本的にはMessage側から呼び出される想定
/// </summary>
public class Mission : MonoBehaviour
{
    [Header("対応したミッションデータをアタッチする")]
    [SerializeField]
    private MissionData _missionData;

    [Space(15f)]
    [Header("ミッションをスタートさせる場合は有効にする")]
    [SerializeField]
    private bool _isStartMission = false;
    [Header("ミッションをクリアさせる場合には有効にする")]
    [SerializeField]
    private bool _isClearMission = false;

    /// <summary>
    /// Missionをスタートする関数
    /// 基本的にはMessageInteractから呼び出される想定
    /// </summary>
    public void StartMission()
    {
        MissionManager.Instance.StartMission(_missionData);
    }

    /// <summary>
    /// Missionをクリアする関数
    /// 基本的にはMessageInteractから呼び出される想定
    /// </summary>
    public void ClearMission()
    {
        MissionManager.Instance.ClearMission(_missionData);
    }
}
