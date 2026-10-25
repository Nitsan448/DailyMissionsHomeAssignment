using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.DailyMissions.Views
{
    public class DailyMissionsPopupView : MonoBehaviour
    {
        public event Action OnClosePopupButtonPressed;
        public bool IsInitialized => _missionViews.Count > 0;
        
        [SerializeField] private DailyMissionView _missionViewPrefab;
        [SerializeField] private Transform _missionsContainer;
        [SerializeField] private Button _closePopupButton;
        private readonly List<DailyMissionView> _missionViews = new();

        private void OnEnable()
        {
            _closePopupButton.onClick.AddListener(() => OnClosePopupButtonPressed?.Invoke());
        }

        public DailyMissionView CreateMissionView()
        {
            var missionView = Instantiate(_missionViewPrefab, _missionsContainer);
            _missionViews.Add(missionView);
            return missionView;
        }

        private void OnDisable()
        {
            _closePopupButton.onClick.RemoveAllListeners();
        }
    }
}
