using System;
using System.Collections.Generic;
using System.Linq;
using Core.Extensions;
using Game.Missions;
using Game.Missions.Types;
using UnityEngine;
using VContainer.Unity;
using Random = System.Random;

namespace Game.DailyMissions
{
    public class DailyMissionsService : IDailyMissionsService, IInitializable, IDisposable
    {
        public event Action<MissionBase> MissionStateUpdated;
        public DailyMissionsStreakMission StreakMission { get; private set; }
        public IReadOnlyList<MissionBase> Missions { get; private set; } = Array.Empty<MissionBase>();
        
        private readonly DailyMissionsConfig _dailyMissionsConfig;

        public DailyMissionsService(DailyMissionsConfig config)
        {
            _dailyMissionsConfig = config;
        }

        public void Initialize()
        {
            CreateMissions();
            foreach (var mission in Missions)
            {
                mission.StateUpdated += OnMissionStateUpdated;
            }
            Debug.Log(string.Join(", ", Missions.Select(mission => mission.Config.Id)));
        }

        private void CreateMissions()
        {
            Missions = _dailyMissionsConfig.Missions.GetRandomUniqueElements(_dailyMissionsConfig.DailyMissionsCount, new Random())
                .Select(config => new ManualMission(config))
                .ToList();
            StreakMission = new DailyMissionsStreakMission(Missions, _dailyMissionsConfig.StreakMission);
        }

        private void OnMissionStateUpdated(MissionBase mission)
        {
            MissionStateUpdated?.Invoke(mission);
        }

        public void Dispose()
        {
            foreach (var mission in Missions)
            {
                mission.StateUpdated -= OnMissionStateUpdated;
            }
            StreakMission.Dispose();
        }
    }
}
