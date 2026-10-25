using System;
using System.Collections.Generic;
using Game.Missions;
using Game.Missions.Types;

namespace Game.DailyMissions.Service
{
    public interface IDailyMissionsService
    {
        public event Action<MissionBase> MissionStateUpdated;
        public DailyMissionsStreakMission StreakMission { get; }
        public IReadOnlyList<MissionBase> Missions { get; }
    }
}