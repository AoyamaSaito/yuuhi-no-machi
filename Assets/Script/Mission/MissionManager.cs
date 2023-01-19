using System.Collections.Generic;
using UnityEngine;

public class MissionManager
{
    #regionÅ@ Singleton
    private static MissionManager _instance;
    public static MissionManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MissionManager();
            }
            return _instance;
        }
    }
    #endregion

    private List<MissionData> _missionDatas = new List<MissionData>();

    public void StartMission(MissionData missionData)
    {
        _missionDatas.Add(missionData);
    }

    public void ClearMission(MissionData missionData)
    {
        _missionDatas.Remove(missionData);
    }
}
