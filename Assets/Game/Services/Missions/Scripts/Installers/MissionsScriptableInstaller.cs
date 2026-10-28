using Core.Installers;
using Game.Services.Missions.Scripts.Implementations;
using UnityEngine;
using VContainer;

namespace Game.Services.Missions.Scripts.Installers
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Installers/MissionsInstaller", fileName = "MissionsInstaller")]
    public class MissionsScriptableInstaller : ScriptableInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<MissionsFactory>(Lifetime.Singleton);
            builder.Register<ManualMissionFactory>(Lifetime.Singleton).As<IMissionFactory>();
        }
    }
}
