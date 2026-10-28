using Core.Installers;
using Game.DailyMissions.Config;
using Game.DailyMissions.MissionImplementations;
using Game.DailyMissions.Service;
using Game.Missions;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.DailyMissions.Installers
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Installers/DailyMissionsInstaller", fileName = "DailyMissionsInstaller")]
    public class DailyMissionsScriptableInstaller : ScriptableInstaller
    {
        [SerializeField] private DailyMissionsConfig _dailyMissionsConfig;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(_dailyMissionsConfig);
            builder.RegisterEntryPoint<DailyMissionsService>();
            builder.Register<DailyMissionsStreakMissionFactory>(Lifetime.Singleton).As<IMissionFactory>();
        }
    }
}
