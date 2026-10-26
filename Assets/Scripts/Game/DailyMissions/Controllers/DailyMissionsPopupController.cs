using System;
using System.Collections.Generic;
using Game.DailyMissions.Service;
using Game.DailyMissions.Views;
using JetBrains.Annotations;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace Game.DailyMissions.Controllers
{
    [UsedImplicitly]
    public class DailyMissionsPopupController : IInitializable, IDisposable
    {
        private readonly IDailyMissionsService _dailyMissionsService;
        private readonly DailyMissionsPopupView _popupView;
        private readonly Button _openDailyMissionsPopupButton;
        private readonly List<DailyMissionController> _dailyMissionControllers = new();

        public DailyMissionsPopupController(
            IDailyMissionsService dailyMissionsService,
            DailyMissionsPopupView popupView,
            [Key(Ids.Buttons.OPEN_DAILY_MISSIONS_POPUP)] Button openDailyMissionsPopupButton)
        {
            _dailyMissionsService = dailyMissionsService;
            _popupView = popupView;
            _openDailyMissionsPopupButton = openDailyMissionsPopupButton;
        }

        public void Initialize()
        {
            _openDailyMissionsPopupButton.onClick.AddListener(OnOpenPopupButtonPressed);
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
                var dailyMissionView = _popupView.CreateMissionView();
                var dailyMissionController = new DailyMissionController(dailyMissionView, mission);
                _dailyMissionControllers.Add(dailyMissionController);
                dailyMissionController.Initialize();
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
            _openDailyMissionsPopupButton.onClick.RemoveListener(OnOpenPopupButtonPressed);
            _popupView.ClosePopupButtonPressed -= OnClosePopupButtonPressed;
            _dailyMissionsService.MissionsReset -= OnMissionsReset;
            DisposeMissionControllers();
        }
    }
}
