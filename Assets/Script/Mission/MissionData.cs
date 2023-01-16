using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CreateMissionAsset")]
public class MissionData : ScriptableObject
{
    [SerializeField]
    private MissionId _missionId = MissionId.None;
    [SerializeField]
    private string _missionName = "’T‚µ•¨";
    [SerializeField]
    private string _missionText = "‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ";

    public MissionId MissionId => _missionId;
    public string MissionName => _missionName;
    public string MissionText => _missionText;
}
