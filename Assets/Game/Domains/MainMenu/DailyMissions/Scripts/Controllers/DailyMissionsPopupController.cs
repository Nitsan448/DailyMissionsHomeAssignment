using System;
using System.Collections.Generic;
using Game.Domains.MainMenu.DailyMissions.Views;
using Game.Services.DailyMissions.Scripts.Service;
using Game.UI.Missions.Scripts.Controllers;
using JetBrains.Annotations;
using VContainer.Unity;

namespace Game.Domains.MainMenu.DailyMissions.Controllers
{
    [UsedImplicitly]
    public class DailyMissionsPopupController : IStartable, IDisposable
    {
        private readonly IDailyMissionsService _dailyMissionsService;
        private readonly DailyMissionsPopupView _popupView;
        private readonly DailyMissionsMainScreenView _dailyMissionsMainScreenView;
        private readonly List<MissionController> _dailyMissionControllers = new();

        public DailyMissionsPopupController(
            IDailyMissionsService dailyMissionsService,
            DailyMissionsPopupView popupView,
            DailyMissionsMainScreenView dailyMissionsMainScreenView)
        {
            _dailyMissionsService = dailyMissionsService;
            _popupView = popupView;
            _dailyMissionsMainScreenView = dailyMissionsMainScreenView;
        }

        public void Start()
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
                var missionView = _popupView.CreateMissionView(mission.Config.Type);
                var missionController = new MissionController(missionView, mission);
                _dailyMissionControllers.Add(missionController);
                missionController.Initialize();
            }
        }

        private void OnClosePopupButtonPressed()
        {
            _popupView.gameObject.SetActive(false);
        }

        private void OnMissionsReset()
        {
            DisposeMissionControllers();
            _popupView.DestroyMissionViews();
            if (_popupView.gameObject.activeSelf)
            {
                CreateMissions();
            }
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
