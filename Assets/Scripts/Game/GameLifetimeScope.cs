using VContainer;
using VContainer.Unity;

namespace Game.Game
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // builder.Register<ScoreService>(Lifetime.Singleton);
        }
    }
}
