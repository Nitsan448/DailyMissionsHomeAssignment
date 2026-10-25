using Game.DailyMissions;
using Game.DailyMissions.Controllers;
using Game.DailyMissions.Views;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private DailyMissionsConfig _dailyMissionsConfig;
        [SerializeField] private DailyMissionsPopupView _dailyMissionsPopupView;
        [SerializeField] private Button _openDailyMissionsPopupButton;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_dailyMissionsConfig);
            builder.RegisterEntryPoint<DailyMissionsService>();
            builder.RegisterComponent(_dailyMissionsPopupView);
            builder.RegisterComponent(_openDailyMissionsPopupButton).Keyed(Ids.Buttons.OPEN_DAILY_MISSIONS_POPUP);
            builder.RegisterEntryPoint<DailyMissionsPopupController>();
        }
    }
}
