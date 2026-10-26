using System;
using UnityEngine;

namespace Game.DailyMissions.Config
{
    [Serializable]
    public class DailyMissionViewStateConfig
    {
        public Color BackgroundColor;
        public Color TextColor;
        public bool ShouldShowReward;
        public bool ShouldShowCollectedIcon;
    }
}