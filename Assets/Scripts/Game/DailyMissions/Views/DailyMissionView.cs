using TMPro;
using UnityEngine;

namespace Game.DailyMissions.Views
{
    public class DailyMissionView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private TextMeshProUGUI _coinRewardAmountText;

        public void Dress(DailyMissionViewDressCode dressCode)
        {
            _descriptionText.text = dressCode.Description;
            _coinRewardAmountText.text = dressCode.CoinRewardAmount.ToString();
        }
    }
}
