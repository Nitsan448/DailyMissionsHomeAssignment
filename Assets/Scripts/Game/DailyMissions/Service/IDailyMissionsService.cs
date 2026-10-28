using System;
using System.Collections.Generic;
using Game.Missions.Base;

namespace Game.DailyMissions.Service
{
    public interface IDailyMissionsService
    {
        event Action MissionsReset;
        event Action<MissionBase> MissionStateUpdated;
        IReadOnlyList<MissionBase> Missions { get; }
        void ResetMissions();
    }
}
