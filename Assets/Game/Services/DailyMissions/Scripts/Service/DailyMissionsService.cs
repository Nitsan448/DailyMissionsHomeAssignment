using System;
using System.Collections.Generic;
using System.Linq;
using Core.Extensions;
using Game.Services.DailyMissions.Scripts.Config;
using Game.Services.Missions;
using Game.Services.Missions.Scripts;
using Game.Services.Missions.Scripts.Config;
using Game.Services.Missions.Scripts.Factory;
using JetBrains.Annotations;
using UnityEngine;
using VContainer.Unity;
using Random = System.Random;

namespace Game.Services.DailyMissions.Scripts.Service
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
        
        public void ResetMissions()
        {
            DisposeMissions();
            InitializeMissions();
            MissionsReset?.Invoke();
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
            var validMissionsPool = GetValidMissions(_dailyMissionsConfig.MissionsPool);
            var randomMissions = validMissionsPool.GetRandomUniqueElements(_dailyMissionsConfig.RandomizedDailyMissionsCount, new Random());
            var validAlwaysIncludedMissions = GetValidMissions(_dailyMissionsConfig.AlwaysIncludedMissions);
            var missionConfigs = validAlwaysIncludedMissions.Concat(randomMissions);
            Missions = missionConfigs.Select(_missionsFactory.Create).ToList();
        }

        private List<MissionConfig> GetValidMissions(IEnumerable<MissionConfig> missionConfigs)
        {
            var validMissions = new List<MissionConfig>();
            foreach (var missionConfig in missionConfigs)
            {
                if (!_missionsFactory.HasFactory(missionConfig.Type))
                {
                    Debug.LogError($"Skipping mission '{missionConfig.Id}': no factory registered for mission type {missionConfig.Type}");
                    continue;
                }
                validMissions.Add(missionConfig);
            }
            return validMissions;
        }
        
        private void OnMissionStateUpdated(MissionBase mission)
        {
            MissionStateUpdated?.Invoke(mission);
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
