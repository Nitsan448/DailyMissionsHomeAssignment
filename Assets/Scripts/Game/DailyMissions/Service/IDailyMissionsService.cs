using System;
using System.Collections.Generic;
using Game.Missions;
using Game.Missions.Types;

namespace Game.DailyMissions.Service
{
    public interface IDailyMissionsService
    {
        event Action MissionsReset;
        event Action<MissionBase> MissionStateUpdated;
        DailyMissionsStreakMission StreakMission { get; }
        IReadOnlyList<MissionBase> Missions { get; }
        void ResetMissions();
    }
}