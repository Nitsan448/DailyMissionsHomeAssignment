using Core.Installers;
using Game.Missions.Implementations;
using UnityEngine;
using VContainer;

namespace Game.Missions.Installers
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Installers/MissionsInstaller", fileName = "MissionsInstaller")]
    public class MissionsScriptableInstaller : ScriptableInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<MissionsFactory>(Lifetime.Singleton);
            MissionsFactory.RegisterFactory(builder, MissionType.Manual, (_, config) => new ManualMission(config));
        }
    }
}
