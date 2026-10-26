using System;
using System.Collections.Generic;
using System.Linq;
using Game.DailyMissions.Service;
using Game.DailyMissions.Views;
using Game.Missions;
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
            var sortedMissions = _dailyMissionsService.Missions.OrderBy(mission => mission.State == EMissionState.Completed)
                .ThenBy(mission => mission.State == EMissionState.InProgress)
                .ToList();
            foreach (var mission in sortedMissions)
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

        public void Dispose()
        {
            _popupView.ClosePopupButtonPressed -= OnClosePopupButtonPressed;
            _openDailyMissionsPopupButton.onClick.RemoveListener(OnOpenPopupButtonPressed);
        }
    }
}
