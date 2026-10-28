using System;
using System.Collections.Generic;
using System.Linq;
using Game.Missions.Base;
using Game.Missions.Config;

namespace Game.Missions
{
    //Generated with AI Assistance
    public class MissionsFactory
    {
        private readonly Dictionary<MissionType, IMissionFactory> _factories;

        public MissionsFactory(IReadOnlyList<IMissionFactory> factories)
        {
            _factories = factories.ToDictionary(factory => factory.Type);
        }

        public MissionBase Create(MissionConfig config)
        {
            if (!_factories.TryGetValue(config.Type, out var factory))
            {
                throw new ArgumentOutOfRangeException($"No factory registered for mission type {config.Type}");
            }
            return factory.Create(config);
        }
    }
}
