using Game.Game.DailyMissions;
using Game.Game.DailyMissions.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Game
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private DailyMissionsConfig _dailyMissionsConfig;
        [SerializeField] private DailyMissionsPopup _dailyMissionsPopup;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_dailyMissionsConfig);
            builder.RegisterEntryPoint<DailyMissionsService>();
            builder.RegisterComponent(_dailyMissionsPopup);
        }
    }
}
