using System;
using Game.DailyMissions.Service;
using Game.DailyMissions.Views;
using Game.Missions.Types;
using JetBrains.Annotations;
using VContainer.Unity;

namespace Game.DailyMissions.Controllers
{
    //Generated with AI assistance
    [UsedImplicitly]
    public class DailyMissionsMainScreenController : IInitializable, IDisposable
    {
        private readonly IDailyMissionsService _dailyMissionsService;
        private readonly DailyMissionsMainScreenView _mainScreenView;

        public DailyMissionsMainScreenController(IDailyMissionsService dailyMissionsService, DailyMissionsMainScreenView mainScreenView)
        {
            _dailyMissionsService = dailyMissionsService;
            _mainScreenView = mainScreenView;
        }

        public void Initialize()
        {
            _mainScreenView.ResetMissionsButtonClicked += OnResetMissionsButtonClicked;
            _mainScreenView.CompleteMissionButtonClicked += OnCompleteMissionButtonClicked;
            _dailyMissionsService.MissionsReset += OnMissionsReset;
            InitializeCompleteMissionButtons();
        }

        private void OnResetMissionsButtonClicked()
        {
            _dailyMissionsService.ResetMissions();
        }

        private void OnCompleteMissionButtonClicked(int missionIndex)
        {
            if (_dailyMissionsService.Missions[missionIndex] is ManualMission manualMission)
            {
                manualMission.Complete();
            }
        }

        private void OnMissionsReset()
        {
            InitializeCompleteMissionButtons();
        }

        private void InitializeCompleteMissionButtons()
        {
            _mainScreenView.InitializeCompleteMissionButtons(_dailyMissionsService.Missions.Count);
        }

        public void Dispose()
        {
            _dailyMissionsService.MissionsReset -= OnMissionsReset;
            _mainScreenView.CompleteMissionButtonClicked -= OnCompleteMissionButtonClicked;
            _mainScreenView.ResetMissionsButtonClicked -= OnResetMissionsButtonClicked;
        }
    }
}
