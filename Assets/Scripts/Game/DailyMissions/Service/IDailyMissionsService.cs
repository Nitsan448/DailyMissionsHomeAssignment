using System;
using System.Collections.Generic;
using Game.Missions.Base;

namespace Game.DailyMissions.Service
{
    public interface IDailyMissionsService
    {
        event Action MissionsReset;
        MissionBase StreakMission { get; }
        IReadOnlyList<MissionBase> Missions { get; }
        void ResetMissions();
    }
}