using UnityEngine;
using VContainer;

namespace Game.Game.DailyMissions.UI
{
    public class DailyMissionsPopup : MonoBehaviour
    {
        [SerializeField] private DailyMissionView _missionViewPrefab;
        [SerializeField] private Transform _missionsContainer;

        private IDailyMissionsService _dailyMissionsService;

        [Inject]
        public void Construct(IDailyMissionsService dailyMissionsService)
        {
            _dailyMissionsService = dailyMissionsService;
        }

        private void Start()
        {
            foreach (var mission in _dailyMissionsService.Missions)
            {
                Instantiate(_missionViewPrefab, _missionsContainer).Init(mission);
            }
        }
    }
}
