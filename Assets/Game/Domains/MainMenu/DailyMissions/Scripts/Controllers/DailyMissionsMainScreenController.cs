using System;
using System.Collections.Generic;
using System.Linq;
using Game.Domains.MainMenu.DailyMissions.Views;
using Game.Services.DailyMissions.Scripts.Service;
using Game.Services.Missions.Scripts.Implementations;
using JetBrains.Annotations;
using VContainer.Unity;

namespace Game.Domains.MainMenu.DailyMissions.Controllers
{
    [UsedImplicitly]
    public class DailyMissionsMainScreenController : IStartable, IDisposable
    {
        private readonly IDailyMissionsService _dailyMissionsService;
        private readonly DailyMissionsMainScreenView _mainScreenView;
        private IReadOnlyList<ManualMission> _manualMissions;

        public DailyMissionsMainScreenController(IDailyMissionsService dailyMissionsService, DailyMissionsMainScreenView mainScreenView)
        {
            _dailyMissionsService = dailyMissionsService;
            _mainScreenView = mainScreenView;
        }

        public void Start()
        {
            _mainScreenView.ResetMissionsButtonPressed += OnResetMissionsButtonPressed;
            _mainScreenView.CompleteMissionButtonPressed += OnCompleteMissionButtonPressed;
            _dailyMissionsService.MissionsReset += OnMissionsReset;
            InitializeCompleteMissionButtons();
        }

        private void OnResetMissionsButtonPressed()
        {
            _dailyMissionsService.ResetMissions();
        }

        private void OnCompleteMissionButtonPressed(int missionIndex)
        {
            _manualMissions[missionIndex].Complete();
        }

        private void OnMissionsReset()
        {
            InitializeCompleteMissionButtons();
        }

        private void InitializeCompleteMissionButtons()
        {
            _manualMissions = _dailyMissionsService.Missions.OfType<ManualMission>().ToList();
            _mainScreenView.InitializeCompleteMissionButtons(_manualMissions.Count);
        }

        public void Dispose()
        {
            _dailyMissionsService.MissionsReset -= OnMissionsReset;
            _mainScreenView.CompleteMissionButtonPressed -= OnCompleteMissionButtonPressed;
            _mainScreenView.ResetMissionsButtonPressed -= OnResetMissionsButtonPressed;
        }
    }
}
