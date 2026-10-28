using System;
using Game.Services.Missions.Scripts;
using Game.Services.Missions.Scripts.Base;
using Game.UI.Missions.Scripts.Views;

namespace Game.UI.Missions.Scripts.Controllers
{
    public class MissionController : IDisposable
    {
        private readonly MissionView _view;
        private readonly MissionBase _mission;

        public MissionController(MissionView view, MissionBase mission)
        {
            _view = view;
            _mission = mission;
        }

        public void Initialize()
        {
            _mission.StateUpdated += OnMissionStateUpdated;
            _view.Clicked += OnViewClicked;
            var dressCode = new MissionViewDressCode()
            {
                Description = _mission.Config.Description,
                CoinRewardAmount = _mission.Config.CoinRewardAmount,
                State =  _mission.State,
            };
            _view.Dress(dressCode);
        }

        private void OnMissionStateUpdated(MissionBase mission)
        {
            _view.UpdateState(mission.State);
        }

        private void OnViewClicked()
        {
            if (_mission.State == EMissionState.Completed)
            {
                _mission.Collect();
            }
        }

        public void Dispose()
        {
            _mission.StateUpdated -= OnMissionStateUpdated;
            _view.Clicked -= OnViewClicked;
        }
    }
}
