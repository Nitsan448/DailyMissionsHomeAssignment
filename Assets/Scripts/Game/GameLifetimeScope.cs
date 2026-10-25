using Game.Game.DailyMissions;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Game
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private DailyMissionsConfig _dailyMissionsConfig;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_dailyMissionsConfig);
            builder.RegisterEntryPoint<DailyMissionsService>();
        }
    }
}
