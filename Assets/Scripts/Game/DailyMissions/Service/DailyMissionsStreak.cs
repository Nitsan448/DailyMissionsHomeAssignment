using System.Collections.Generic;
using Game.Missions;

namespace Game.DailyMissions.Service
{
    public class DailyMissionsStreak : MissionBase
    {
        private readonly IReadOnlyList<MissionBase> _missions;
        private int _collectedMissionsCount = 0;

        public DailyMissionsStreak(IReadOnlyList<MissionBase> missions, MissionConfig config) : base(config)
        {
            _missions = missions;
            foreach (var mission in _missions)
            {
                mission.StateUpdated += OnMissionStateUpdated;
            }
        }

        private void OnMissionStateUpdated(MissionBase mission)
        {
            if (mission.State == EMissionState.Collected)
            {
                _collectedMissionsCount++;
                if (_collectedMissionsCount == _missions.Count)
                {
                    UpdateState(EMissionState.Completed);
                }
            }
        }

        public override void Dispose()
        {
            foreach (var mission in _missions)
            {
                mission.StateUpdated -= OnMissionStateUpdated;
            }
        }

    }
}