using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CreateMissionAsset")]
public class MissionData : ScriptableObject
{
    [SerializeField]
    private MissionId _missionId = MissionId.None;
    [SerializeField]
    private string _missionName = "探し物";
    [SerializeField]
    private string _missionText = "ああああああああああああああああ";

    public MissionId MissionId => _missionId;
    public string MissionName => _missionName;
    public string MissionText => _missionText;
}
