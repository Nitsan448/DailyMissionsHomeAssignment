using System.Linq;
using Game.Services.DailyMissions.Scripts.Service;
using Game.Services.Missions;
using Game.Services.Missions.Scripts;
using Game.Services.Missions.Scripts.Config;
using Game.Services.Missions.Scripts.Enums;

namespace Game.Services.DailyMissions.Scripts.MissionImplementations
{
    public class DailyMissionsStreakMission : MissionBase
    {
        private readonly IDailyMissionsService _dailyMissionsService;

        public DailyMissionsStreakMission(MissionConfig config, IDailyMissionsService dailyMissionsService) : base(config)
        {
            _dailyMissionsService = dailyMissionsService;
            _dailyMissionsService.MissionStateUpdated += OnMissionStateUpdated;
        }

        private void OnMissionStateUpdated(MissionBase mission)
        {
            if (State != EMissionState.InProgress)
            {
                return;
            }
            if (_dailyMissionsService.Missions.Where(m => m is not DailyMissionsStreakMission) 
                .All(m => m.State == EMissionState.Collected))
            {
                UpdateState(EMissionState.Completed);
            }
        }

        public override void Dispose()
        {
            _dailyMissionsService.MissionStateUpdated -= OnMissionStateUpdated;
        }
    }
}
