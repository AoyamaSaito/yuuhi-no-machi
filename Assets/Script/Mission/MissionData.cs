using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CreateMissionAsset")]
public class MissionData : ScriptableObject
{
    [SerializeField]
    private MissionId _missionId = MissionId.None;
    [SerializeField]
    private string _title = "’T‚µ•¨";
    [SerializeField]
    private string _information = "‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ";

    public MissionId MissionId => _missionId;
    public string Title => _title;
    public string Information => _information;
}
