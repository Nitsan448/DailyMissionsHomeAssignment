using System;
using System.Collections.Generic;
using System.Linq;
using Core.Extensions;
using Game.DailyMissions.Config;
using Game.Missions;
using Game.Missions.Typed;
using JetBrains.Annotations;
using VContainer.Unity;
using Random = System.Random;

namespace Game.DailyMissions.Service
{
    [UsedImplicitly]
    public class DailyMissionsService : IDailyMissionsService, IInitializable, IDisposable
    {
        public event Action MissionsReset;
        public MissionBase Streak { get; private set; }
        public IReadOnlyList<TypedMissionBase> Missions { get; private set; } = Array.Empty<TypedMissionBase>();
        
        private readonly DailyMissionsConfig _dailyMissionsConfig;

        public DailyMissionsService(DailyMissionsConfig config)
        {
            _dailyMissionsConfig = config;
        }

        public void Initialize()
        {
            InitializeMissions();
        }

        private void InitializeMissions()
        {
            CreateMissions();
        }

        private void CreateMissions()
        {
            Missions = _dailyMissionsConfig.Missions.GetRandomUniqueElements(_dailyMissionsConfig.DailyMissionsCount, new Random())
                .Select(config => new ManualMission(config))
                .ToList();
            Streak = new DailyMissionsStreak(Missions, _dailyMissionsConfig.StreakMission);
        }
        
        public void ResetMissions()
        {
            DisposeMissions();
            InitializeMissions();
            MissionsReset?.Invoke();
        }
        
        private void DisposeMissions()
        {
            foreach (var mission in Missions)
            {
                mission.Dispose();
            }
            Streak.Dispose();
        }

        public void Dispose()
        {
            DisposeMissions();
        }
    }
}
