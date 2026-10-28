using System;
using System.Collections.Generic;
using Game.Services.Missions.Scripts;
using Game.UI.Missions.Scripts.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Domains.MainMenu.DailyMissions.Scripts.Views
{
    public class DailyMissionsPopupView : MonoBehaviour
    {
        public event Action ClosePopupButtonPressed;
        
        [SerializeField] private DailyMissionViewSlot _missionViewSlot;
        [SerializeField] private DailyMissionViewSlot _streakMissionViewSlot;
        [SerializeField] private Button _closePopupButton;
        [SerializeField] private ScrollRect _missionsScrollRect;
        private readonly List<MissionView> _missionViews = new();

        private void OnEnable()
        {
            _closePopupButton.onClick.AddListener(OnClosePopupButtonPressed);
            _missionsScrollRect.verticalNormalizedPosition = 1;
        }
        
        public MissionView CreateMissionView(MissionType type)
        {
            var slot = type == MissionType.DailyMissionsStreak ? _streakMissionViewSlot : _missionViewSlot;
            var missionView = Instantiate(slot.Prefab, slot.Container);
            _missionViews.Add(missionView);
            return missionView;
        }

        public void DestroyMissionViews()
        {
            foreach (var missionView in _missionViews)
            {
                Destroy(missionView.gameObject);
            }
            _missionViews.Clear();
        }

        private void OnClosePopupButtonPressed()
        {
            ClosePopupButtonPressed?.Invoke();
        }
        
        private void OnDisable()
        {
            _closePopupButton.onClick.RemoveListener(OnClosePopupButtonPressed);
        }
    }
}
