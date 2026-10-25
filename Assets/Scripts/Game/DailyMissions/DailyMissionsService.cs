using System.Collections.Generic;
using System.Linq;
using Core.Helpers;
using Game.Game.Missions;
using UnityEngine;
using VContainer.Unity;
using Random = System.Random;

namespace Game.Game.DailyMissions
{
    public class DailyMissionsService : IDailyMissionsService, IInitializable
    {
        public Mission StreakMission { get; private set; }
        public List<Mission> Missions { get; private set; } = new();
        
        private readonly DailyMissionsConfig _dailyMissionsConfig;

        public DailyMissionsService(DailyMissionsConfig config)
        {
            _dailyMissionsConfig = config;
        }

        public void Initialize()
        {
            StreakMission = new Mission(_dailyMissionsConfig.StreakMission);
            Missions = _dailyMissionsConfig.Missions.GetRandomUniqueElements(3, new Random())
                .Select(config => new Mission(config))
                .ToList();
            Debug.Log(string.Join(", ", Missions.Select(mission => mission.Config.Id)));
        }
    }
}
