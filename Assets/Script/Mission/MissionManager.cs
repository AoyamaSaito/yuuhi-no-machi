using System;
using System.Collections;
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

    private List<Mission> _missions = new List<Mission>();

    public void AddMission(Mission mission)
    {
        _missions.Add(mission);
    }
}
