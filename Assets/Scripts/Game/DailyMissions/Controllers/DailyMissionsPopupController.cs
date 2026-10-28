using System;
using System.Collections.Generic;
using Game.DailyMissions.Service;
using Game.DailyMissions.Views;
using Game.Missions;
using JetBrains.Annotations;
using VContainer.Unity;

namespace Game.DailyMissions.Controllers
{
    [UsedImplicitly]
    public class DailyMissionsPopupController : IInitializable, IDisposable
    {
        private readonly IDailyMissionsService _dailyMissionsService;
        private readonly DailyMissionsPopupView _popupView;
        private readonly DailyMissionsMainScreenView _dailyMissionsMainScreenView;
        private readonly List<DailyMissionController> _dailyMissionControllers = new();

        public DailyMissionsPopupController(
            IDailyMissionsService dailyMissionsService,
            DailyMissionsPopupView popupView,
            DailyMissionsMainScreenView dailyMissionsMainScreenView)
        {
            _dailyMissionsService = dailyMissionsService;
            _popupView = popupView;
            _dailyMissionsMainScreenView = dailyMissionsMainScreenView;
        }

        public void Initialize()
        {
            _dailyMissionsMainScreenView.OpenPopupButtonPressed += OnOpenPopupButtonPressed;
            _popupView.ClosePopupButtonPressed += OnClosePopupButtonPressed;
            _dailyMissionsService.MissionsReset += OnMissionsReset;
        }

        private void OnOpenPopupButtonPressed()
        {
            if (_dailyMissionControllers.Count == 0)
            {
                CreateMissions();
            }
            _popupView.gameObject.SetActive(true);
        }
        
        private void CreateMissions()
        {
            foreach (var mission in _dailyMissionsService.Missions)
            {
                var missionView = _popupView.CreateMissionView();
                CreateMissionController(mission, missionView);
            }

            var streakView = _popupView.CreateStreakView();
            CreateMissionController(_dailyMissionsService.Streak, streakView);
        }

        private void CreateMissionController(MissionBase mission, DailyMissionView missionView)
        {
            var dailyMissionController = new DailyMissionController(missionView, mission);
            _dailyMissionControllers.Add(dailyMissionController);
            dailyMissionController.Initialize();
        }

        private void OnClosePopupButtonPressed()
        {
            _popupView.gameObject.SetActive(false);
        }

        private void OnMissionsReset()
        {
            DisposeMissionControllers();
            _popupView.DestroyMissionViews();
        }

        private void DisposeMissionControllers()
        {
            foreach (var dailyMissionController in _dailyMissionControllers)
            {
                dailyMissionController.Dispose();
            }
            _dailyMissionControllers.Clear();
        }

        public void Dispose()
        {
            _dailyMissionsMainScreenView.OpenPopupButtonPressed -= OnOpenPopupButtonPressed;
            _popupView.ClosePopupButtonPressed -= OnClosePopupButtonPressed;
            _dailyMissionsService.MissionsReset -= OnMissionsReset;
            DisposeMissionControllers();
        }
    }
}
