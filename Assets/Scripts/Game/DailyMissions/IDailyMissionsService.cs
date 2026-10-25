using System;
using System.Collections.Generic;
using Game.Game.Missions;

namespace Game.Game.DailyMissions
{
    public interface IDailyMissionsService
    {
        public event Action<MissionBase> MissionStateUpdated;
        public MissionBase StreakMission { get; }
        public List<MissionBase> Missions { get; }
    }
}