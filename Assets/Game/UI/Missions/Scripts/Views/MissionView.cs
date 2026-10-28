using System;
using Game.Services.Missions.Scripts;
using Game.UI.Missions.Scripts.Config;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Missions.Scripts.Views
{
    public class MissionView : MonoBehaviour
    {
        public event Action Clicked;

        [SerializeField] private Button _button;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private TextMeshProUGUI _coinRewardAmountText;
        [SerializeField] private GameObject _reward;
        [SerializeField] private GameObject _collectedIcon;
        [SerializeField] private MissionViewStatesConfig _statesConfig;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            Clicked?.Invoke();
        }

        public void Dress(MissionViewDressCode dressCode)
        {
            _descriptionText.text = dressCode.Description;
            _coinRewardAmountText.text = dressCode.CoinRewardAmount.ToString();
            UpdateState(dressCode.State);
        }

        public void UpdateState(EMissionState state)
        {
            var stateConfig = _statesConfig.StateConfigs[state];
            _descriptionText.color = stateConfig.TextColor;
            _coinRewardAmountText.color = stateConfig.TextColor;
            _backgroundImage.color = stateConfig.BackgroundColor;
            _reward.SetActive(stateConfig.ShouldShowReward);
            _collectedIcon.SetActive(stateConfig.ShouldShowCollectedIcon);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }
    }
}
