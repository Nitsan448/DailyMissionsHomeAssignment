using System;
using System.Collections.Generic;
using Game.Services.Missions.Scripts;

namespace Game.Services.DailyMissions.Scripts.Service
{
    public interface IDailyMissionsService
    {
        event Action MissionsReset;
        event Action<MissionBase> MissionStateUpdated;
        IReadOnlyList<MissionBase> Missions { get; }
        void ResetMissions();
    }
}
