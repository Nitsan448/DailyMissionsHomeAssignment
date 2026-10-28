using System.Collections.Generic;
using Core.Installers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private List<MonoInstaller> _monoInstallers;
        [SerializeField] private List<ScriptableInstaller> _scriptableInstallers;

        protected override void Configure(IContainerBuilder builder)
        {
            foreach (var installer in _monoInstallers)
            {
                installer.Install(builder);
            }
            foreach (var installer in _scriptableInstallers)
            {
                installer.Install(builder);
            }
        }
    }
}
