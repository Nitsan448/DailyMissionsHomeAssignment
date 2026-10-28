using System;
using UnityEngine;

namespace Game.Missions.Config
{
    [Serializable]
    public class MissionConfig
    {
        [field:SerializeField] public string Id { get; private set; }
        [field:SerializeField] public string Description { get; private set; }
        [field:SerializeField] public int CoinRewardAmount { get; private set; }
    }
}