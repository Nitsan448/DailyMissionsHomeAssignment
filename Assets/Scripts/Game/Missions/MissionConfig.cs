using System;
using Game.Game.Missions.Types;
using UnityEngine;

namespace Game.Game.Missions
{
    [Serializable]
    public class MissionConfig
    {
        [field:SerializeField] public string Id { get; private set; }
        [field:SerializeField] public MissionType Type { get; private set; }
        [field:SerializeField] public string Description { get; private set; }
        [field:SerializeField] public int CoinRewardAmount { get; private set; }
    }
}