using System;
using System.Collections.Generic;

namespace Game.Game.Missions.Types
{
    public class DailyMissionsStreakMission : MissionBase, IDisposable
    {
        public override MissionType MissionType => MissionType.DailyMissionsStreak;
        
        private readonly IReadOnlyList<MissionBase> _missions;
        private int _collectedMissionsCount = 0;
        
        public DailyMissionsStreakMission(IReadOnlyList<MissionBase> missions, MissionConfig config) : base(config)
        {
            _missions = missions;
            foreach (var mission in _missions)
            {
                mission.StateUpdated += OnMissionStateUpdated;
            }
        }

        private void OnMissionStateUpdated(MissionBase missionBase)
        {
            if (missionBase.State == EMissionState.Collected)
            {
                _collectedMissionsCount++;
                if (_collectedMissionsCount == _missions.Count)
                {
                    UpdateState(EMissionState.Completed);
                }
            }
        }

        public void Dispose()
        {
            foreach (var mission in _missions)
            {
                mission.StateUpdated -= OnMissionStateUpdated;
            }
        }

    }
}