using System;
using Game.DailyMissions.Views;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace Game.DailyMissions.Controllers
{
    public class DailyMissionsPopupController : IInitializable, IDisposable
    {
        private readonly IDailyMissionsService _dailyMissionsService;
        private readonly DailyMissionsPopupView _popupView;
        private readonly Button _openDailyMissionsPopupButton;

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
            _popupView.OnClosePopupButtonPressed += OnClosePopupButtonPressed;
        }

        private void UpdatePopupViewState(bool isActive)
        {
            if (isActive && !_popupView.IsInitialized)
            {
                CreateMissions();
            }
            _popupView.gameObject.SetActive(isActive);
        }

        private void CreateMissions()
        {
            foreach (var mission in _dailyMissionsService.Missions)
            {
                var dailyMissionView = _popupView.CreateMissionView();
                var dailyMissionController = new DailyMissionController(dailyMissionView, mission);
                dailyMissionController.Initialize();
            }
        }

        private void OnOpenPopupButtonPressed()
        {
            UpdatePopupViewState(true);
        }

        private void OnClosePopupButtonPressed()
        {
            UpdatePopupViewState(false);
        }

        public void Dispose()
        {
            _popupView.OnClosePopupButtonPressed -= OnClosePopupButtonPressed;
            _openDailyMissionsPopupButton.onClick.RemoveAllListeners();
        }
    }
}
