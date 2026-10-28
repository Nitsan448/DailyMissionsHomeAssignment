using Game.DailyMissions.Config;
using Game.DailyMissions.Controllers;
using Game.DailyMissions.Service;
using Game.DailyMissions.Views;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace Game.DailyMissions
{
    public class DailyMissionsInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private DailyMissionsConfig _dailyMissionsConfig;
        [SerializeField] private DailyMissionsPopupView _dailyMissionsPopupView;
        [SerializeField] private Button _openDailyMissionsPopupButton;
        [SerializeField] private DailyMissionsMainScreenView _dailyMissionsMainScreenView;

        public void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(_dailyMissionsConfig);
            builder.RegisterComponent(_dailyMissionsPopupView);
            builder.RegisterComponent(_dailyMissionsMainScreenView);
            
            builder.RegisterEntryPoint<DailyMissionsService>();
            builder.RegisterEntryPoint<DailyMissionsPopupController>();
            builder.RegisterEntryPoint<DailyMissionsMainScreenController>();
        }
    }
}
