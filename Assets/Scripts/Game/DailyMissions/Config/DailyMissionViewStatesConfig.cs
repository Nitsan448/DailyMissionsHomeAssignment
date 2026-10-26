using System.Collections.Generic;
using Game.Missions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.DailyMissions.Config
{
    [CreateAssetMenu(menuName = "ScriptableObjects/DailyMissionViewStatesConfig", fileName = "DailyMissionViewStatesConfig")]
    public class DailyMissionViewStatesConfig : SerializedScriptableObject
    {
        public Dictionary<EMissionState, DailyMissionViewStateConfig> StateConfigs;
    }
}