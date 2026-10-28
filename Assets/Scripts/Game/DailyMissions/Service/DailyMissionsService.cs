using System;
using System.Collections.Generic;
using System.Linq;
using Core.Extensions;
using Game.DailyMissions.Config;
using Game.DailyMissions.MissionImplementations;
using Game.Missions;
using Game.Missions.Base;
using JetBrains.Annotations;
using VContainer.Unity;
using Random = System.Random;

namespace Game.DailyMissions.Service
{
    [UsedImplicitly]
    public class DailyMissionsService : IDailyMissionsService, IInitializable, IDisposable
    {
        public event Action MissionsReset;
        public MissionBase StreakMission { get; private set; }
        public IReadOnlyList<MissionBase> Missions { get; private set; } = Array.Empty<MissionBase>();
        
        private readonly DailyMissionsConfig _dailyMissionsConfig;
        private readonly MissionsFactory _missionsFactory;

        public DailyMissionsService(DailyMissionsConfig config, MissionsFactory missionsFactory)
        {
            _dailyMissionsConfig = config;
            _missionsFactory = missionsFactory;
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
                .Select(_missionsFactory.Create)
                .ToList();
            StreakMission = new DailyMissionsStreakMission(Missions, _dailyMissionsConfig.StreakMission);
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
            StreakMission.Dispose();
        }

        public void Dispose()
        {
            DisposeMissions();
        }
    }
}
