using System;
using System.Collections.Generic;
using System.Linq;
using Game.Services.Missions.Scripts.Config;
using Game.Services.Missions.Scripts.Enums;

namespace Game.Services.Missions.Scripts.Factory
{
    //Generated with AI Assistance
    public class MissionsFactory
    {
        private readonly Dictionary<EMissionType, IMissionFactory> _factories;

        public MissionsFactory(IReadOnlyList<IMissionFactory> factories)
        {
            _factories = factories.ToDictionary(factory => factory.Type);
        }

        public bool HasFactory(EMissionType type)
        {
            return _factories.ContainsKey(type);
        }

        public MissionBase Create(MissionConfig config)
        {
            if (!_factories.TryGetValue(config.Type, out var factory))
            {
                throw new ArgumentOutOfRangeException(nameof(config), config.Type, $"No factory registered for mission type {config.Type}");
            }
            return factory.Create(config);
        }
    }
}
