using System;
using System.Collections.Generic;
using System.Linq;
using Core.Extensions;
using Game.DailyMissions.Config;
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
        public event Action<MissionBase> MissionStateUpdated;
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
            foreach (var mission in Missions)
            {
                mission.StateUpdated += OnMissionStateUpdated;
            }
        }

        private void CreateMissions()
        {
            var randomMissions = _dailyMissionsConfig.Missions.GetRandomUniqueElements(_dailyMissionsConfig.DailyMissionsCount, new Random());
            var missionConfigs = _dailyMissionsConfig.AlwaysIncludedMissions.Concat(randomMissions);
            Missions = missionConfigs.Select(_missionsFactory.Create).ToList();
        }

        private void OnMissionStateUpdated(MissionBase mission)
        {
            MissionStateUpdated?.Invoke(mission);
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
                mission.StateUpdated -= OnMissionStateUpdated;
                mission.Dispose();
            }
        }

        public void Dispose()
        {
            DisposeMissions();
        }
    }
}
