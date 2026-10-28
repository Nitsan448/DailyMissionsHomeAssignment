using Core.Installers;
using Game.Domains.MainMenu.DailyMissions.Scripts.Controllers;
using Game.Domains.MainMenu.DailyMissions.Scripts.Views;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Domains.MainMenu.DailyMissions.Scripts.Installers
{
    public class DailyMissionsMenuMonoInstaller : MonoInstaller
    {
        [SerializeField] private DailyMissionsPopupView _dailyMissionsPopupView;
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
