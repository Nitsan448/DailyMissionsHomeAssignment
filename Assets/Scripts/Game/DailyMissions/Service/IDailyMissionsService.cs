using System;
using System.Collections.Generic;
using Game.Missions;
using Game.Missions.Typed;

namespace Game.DailyMissions.Service
{
    public interface IDailyMissionsService
    {
        event Action MissionsReset;
        MissionBase Streak { get; }
        IReadOnlyList<TypedMissionBase> Missions { get; }
        void ResetMissions();
    }
}