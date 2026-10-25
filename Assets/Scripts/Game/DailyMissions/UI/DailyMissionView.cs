using Game.Game.Missions;
using TMPro;
using UnityEngine;

namespace Game.Game.DailyMissions.UI
{
    public class DailyMissionView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private TextMeshProUGUI _coinRewardAmountText;

        public void Init(MissionBase mission)
        {
            _descriptionText.text = mission.Config.Description;
            _coinRewardAmountText.text = mission.Config.CoinRewardAmount.ToString();
        }
    }
}
