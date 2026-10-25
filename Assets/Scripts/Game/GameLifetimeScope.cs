using Game.DailyMissions;
using Game.DailyMissions.Views;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private DailyMissionsConfig _dailyMissionsConfig;
        [SerializeField] private DailyMissionsPopupView _dailyMissionsPopupView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_dailyMissionsConfig);
            builder.RegisterEntryPoint<DailyMissionsService>();
            builder.RegisterComponent(_dailyMissionsPopupView);
        }
    }
}
