using Game.Missions.Typed;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Missions
{
    public class MissionsInstaller : MonoBehaviour, IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<TypedMissionsFactory>(Lifetime.Singleton);
        }
    }
}
