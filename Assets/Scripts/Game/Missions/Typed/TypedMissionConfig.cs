using System;
using UnityEngine;

namespace Game.Missions.Typed
{
    [Serializable]
    public class TypedMissionConfig : MissionConfig
    {
        [field:SerializeField] public MissionType Type { get; private set; }
    }
}