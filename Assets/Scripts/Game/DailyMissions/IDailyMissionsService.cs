using System;
using System.Collections.Generic;
using Game.Game.Missions;
using Game.Game.Missions.Types;

namespace Game.Game.DailyMissions
{
    public interface IDailyMissionsService
    {
        public event Action<MissionBase> MissionStateUpdated;
        public DailyMissionsStreakMission StreakMission { get; }
        public IReadOnlyList<MissionBase> Missions { get; }
    }
}