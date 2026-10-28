using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.Installers
{
    public abstract class ScriptableInstaller : ScriptableObject, IInstaller
    {
        public abstract void Install(IContainerBuilder builder);
    }
}