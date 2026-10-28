using System;
using Game.Services.Missions.Scripts.Enums;
using UnityEngine;

namespace Game.Services.Missions.Scripts.Config
{
    [Serializable]
    public class MissionConfig
    {
        [field:SerializeField] public string Id { get; private set; }
        [field:SerializeField] public string Description { get; private set; }
        [field:SerializeField] public int CoinRewardAmount { get; private set; }
        [field:SerializeField] public EMissionType Type { get; private set; }
    }
}
