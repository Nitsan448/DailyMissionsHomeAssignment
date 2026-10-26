using System;
using Game.DailyMissions.Views;
using Game.Missions;

namespace Game.DailyMissions.Controllers
{
    public class DailyMissionController : IDisposable
    {
        private readonly DailyMissionView _view;
        private readonly MissionBase _mission;

        public DailyMissionController(DailyMissionView view, MissionBase mission)
        {
            _view = view;
            _mission = mission;
        }

        public void Initialize()
        {
            _mission.StateUpdated += OnMissionStateUpdated;
            var dressCode = new DailyMissionViewDressCode()
            {
                Description = _mission.Config.Description,
                CoinRewardAmount = _mission.Config.CoinRewardAmount,
                State =  _mission.State,
            };
            _view.Dress(dressCode);
        }

        private void OnMissionStateUpdated(MissionBase mission)
        {
            _view.DressState(mission.State);
        }

        public void Dispose()
        {
            _mission.StateUpdated -= OnMissionStateUpdated;
        }
    }
}
