using System;
using System.Collections.Generic;
using Game.Missions;
using UnityEngine;
using UnityEngine.UI;

namespace Game.DailyMissions.Views
{
    public class DailyMissionsPopupView : MonoBehaviour
    {
        public event Action ClosePopupButtonPressed;
        
        [SerializeField] private DailyMissionViewSlot _missionViewSlot;
        [SerializeField] private DailyMissionViewSlot _streakMissionViewSlot;
        [SerializeField] private Button _closePopupButton;
        private readonly List<DailyMissionView> _missionViews = new();

        private void OnEnable()
        {
            _closePopupButton.onClick.AddListener(OnClosePopupButtonPressed);
        }

        private void OnClosePopupButtonPressed()
        {
            ClosePopupButtonPressed?.Invoke();
        }

        public DailyMissionView CreateMissionView(MissionType type)
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

        private void OnDisable()
        {
            _closePopupButton.onClick.RemoveListener(OnClosePopupButtonPressed);
        }
    }
}
