using System;
using Game.Missions.Base;
using Game.Missions.Config;
using VContainer;

namespace Game.Missions
{
    //Generated with AI Assistance
    public class MissionsFactory
    {
        private readonly IObjectResolver _resolver;

        public MissionsFactory(IObjectResolver resolver)
        {
            _resolver = resolver;
        }
        
        public static void RegisterFactory(IContainerBuilder builder, MissionType type, Func<IObjectResolver, MissionConfig, MissionBase> factory)
        {
            builder.RegisterFactory<MissionConfig, MissionBase>(resolver => config => factory(resolver, config), Lifetime.Singleton).Keyed(type);
        }

        public MissionBase Create(MissionConfig config)
        {
            if (!_resolver.TryResolve<Func<MissionConfig, MissionBase>>(out var factory, config.Type))
            {
                throw new ArgumentOutOfRangeException($"No factory registered for mission type {config.Type}");
            }
            return factory(config);
        }
    }
}
