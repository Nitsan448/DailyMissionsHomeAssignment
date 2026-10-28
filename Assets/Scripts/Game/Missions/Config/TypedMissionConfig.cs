using System;
using Game.Missions.Typed;
using UnityEngine;

namespace Game.Missions.Config
{
    [Serializable]
    public class TypedMissionConfig : MissionConfig
    {
        [field:SerializeField] public MissionType Type { get; private set; }
    }
}