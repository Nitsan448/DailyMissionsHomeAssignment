using System.Collections.Generic;
using Game.Services.Missions.Scripts;
using Game.Services.Missions.Scripts.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.UI.Missions.Scripts.Config
{
    [CreateAssetMenu(menuName = "ScriptableObjects/MissionViewStatesConfig", fileName = "MissionViewStatesConfig")]
    public class MissionViewStatesConfig : SerializedScriptableObject
    {
        public Dictionary<EMissionState, MissionViewStateConfig> StateConfigs;
    }
}