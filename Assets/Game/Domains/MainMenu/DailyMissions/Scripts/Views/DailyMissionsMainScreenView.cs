using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Domains.MainMenu.DailyMissions.Scripts.Views
{
    public class DailyMissionsMainScreenView : MonoBehaviour
    {
        public event Action OpenPopupButtonPressed;
        public event Action ResetMissionsButtonPressed;
        public event Action<int> CompleteMissionButtonPressed;

        [SerializeField] private Button _resetMissionsButton;
        [SerializeField] private Button _completeMissionButtonPrefab;
        [SerializeField] private Button _openDailyMissionsPopupButton;
        [SerializeField] private Transform _completeMissionButtonsContainer;

        private readonly List<Button> _completeMissionButtons = new();

        private void OnEnable()
        {
            _resetMissionsButton.onClick.AddListener(OnResetMissionsButtonClicked);
            _openDailyMissionsPopupButton.onClick.AddListener(OnOpenDailyMissionsPopupButtonClicked);
        }

        public void InitializeCompleteMissionButtons(int missionsCount)
        {
            DestroyCompleteMissionButtons();
            for (var i = 0; i < missionsCount; i++)
            {
                CreateCompleteMissionButton(i);
            }
        }

        private void OnResetMissionsButtonClicked()
        {
            ResetMissionsButtonPressed?.Invoke();
        }

        private void OnOpenDailyMissionsPopupButtonClicked()
        {
            OpenPopupButtonPressed?.Invoke();
        }

        private void CreateCompleteMissionButton(int missionIndex)
        {
            var button = Instantiate(_completeMissionButtonPrefab, _completeMissionButtonsContainer);
            button.GetComponentInChildren<TextMeshProUGUI>().text = $"Complete Task {missionIndex + 1}";
            button.onClick.AddListener(() => CompleteMissionButtonPressed?.Invoke(missionIndex));
            _completeMissionButtons.Add(button);
        }

        private void DestroyCompleteMissionButtons()
        {
            foreach (var button in _completeMissionButtons)
            {
                Destroy(button.gameObject);
            }
            _completeMissionButtons.Clear();
        }

        private void OnDisable()
        {
            _resetMissionsButton.onClick.RemoveListener(OnResetMissionsButtonClicked);
            _openDailyMissionsPopupButton.onClick.RemoveListener(OnOpenDailyMissionsPopupButtonClicked);
        }
    }
}