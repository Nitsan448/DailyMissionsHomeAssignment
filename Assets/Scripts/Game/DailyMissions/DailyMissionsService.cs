using System.Collections.Generic;
using System.Linq;
using Game.Game.Missions;
using UnityEngine;
using VContainer.Unity;

namespace Game.Game.DailyMissions
{
    public class DailyMissionsService : IDailyMissionsService, IInitializable
    {
        public Mission StreakMission { get; private set; }
        public List<Mission> Missions { get; private set; }
        
        private readonly DailyMissionsConfig _dailyMissionsConfig;

        public DailyMissionsService(DailyMissionsConfig config)
        {
            _dailyMissionsConfig = config;
        }

        public void Initialize()
        {
            Debug.Log(string.Join(", ", _dailyMissionsConfig.Missions.Select(mission => mission.Id)));
        }
    }
}
