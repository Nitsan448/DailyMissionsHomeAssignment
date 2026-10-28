using Core.Installers;
using Game.Missions.Typed;
using UnityEngine;
using VContainer;

namespace Game.Missions.Installers
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Installers/MissionsInstaller", fileName = "MissionsInstaller")]
    public class MissionsScriptableInstaller : ScriptableInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<TypedMissionsFactory>(Lifetime.Singleton);
        }
    }
}
