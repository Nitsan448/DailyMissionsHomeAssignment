using VContainer;
using VContainer.Unity;

namespace Game
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            foreach (var installer in GetComponents<IInstaller>())
            {
                installer.Install(builder);
            }
        }
    }
}
