using System;
using UnityEngine;

namespace Game.UI.Missions.Scripts.Config
{
    [Serializable]
    public class MissionViewStateConfig
    {
        public Color BackgroundColor;
        public Color TextColor;
        public bool ShouldShowReward;
        public bool ShouldShowCollectedIcon;
    }
}