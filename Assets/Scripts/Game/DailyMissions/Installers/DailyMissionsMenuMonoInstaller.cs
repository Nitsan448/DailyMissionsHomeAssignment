using Core.Installers;
using Game.DailyMissions.Controllers;
using Game.DailyMissions.Views;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace Game.DailyMissions.Installers
{
    public class DailyMissionsMenuMonoInstaller : MonoInstaller
    {
        [SerializeField] private DailyMissionsPopupView _dailyMissionsPopupView;
        [SerializeField] private Button _openDailyMissionsPopupButton;
        [SerializeField] private DailyMissionsMainScreenView _dailyMissionsMainScreenView;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterComponent(_dailyMissionsPopupView);
            builder.RegisterComponent(_dailyMissionsMainScreenView);
            builder.RegisterEntryPoint<DailyMissionsPopupController>();
            builder.RegisterEntryPoint<DailyMissionsMainScreenController>();
        }
    }
}
