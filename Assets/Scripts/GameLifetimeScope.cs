using HomeAssignment.Scoring;
using VContainer;
using VContainer.Unity;

namespace HomeAssignment
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ScoreService>(Lifetime.Singleton);
        }
    }
}
