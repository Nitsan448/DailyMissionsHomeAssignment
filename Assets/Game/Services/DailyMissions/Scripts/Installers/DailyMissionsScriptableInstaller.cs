using Core.Installers;
using Game.Services.DailyMissions.Scripts.Config;
using Game.Services.DailyMissions.Scripts.MissionImplementations;
using Game.Services.DailyMissions.Scripts.Service;
using Game.Services.Missions;
using Game.Services.Missions.Scripts;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Services.DailyMissions.Scripts.Installers
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
