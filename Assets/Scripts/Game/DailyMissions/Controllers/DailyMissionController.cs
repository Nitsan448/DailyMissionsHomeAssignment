using Game.DailyMissions.Views;
using Game.Missions;

namespace Game.DailyMissions.Controllers
{
    public class DailyMissionController
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
            var dressCode = new DailyMissionViewDressCode()
            {
                Description = _mission.Config.Description,
                CoinRewardAmount = _mission.Config.CoinRewardAmount,
                State =  _mission.State,
            };
            _view.Dress(dressCode);
        }
    }
}
