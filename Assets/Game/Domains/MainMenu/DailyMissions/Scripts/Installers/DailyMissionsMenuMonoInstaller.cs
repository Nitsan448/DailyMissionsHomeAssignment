using Core.Installers;
using Game.Domains.MainMenu.DailyMissions.Controllers;
using Game.Domains.MainMenu.DailyMissions.Views;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace Game.Domains.MainMenu.DailyMissions.Installers
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
