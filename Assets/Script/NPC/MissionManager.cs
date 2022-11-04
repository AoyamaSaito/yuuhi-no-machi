using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager
{
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

    private Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
}
