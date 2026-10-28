using System;
using System.Collections.Generic;
using Game.Missions.Base;
using Game.Missions.Config;
using Game.Missions.Implementations;

namespace Game.Missions
{
    //Generated with AI Assistance
    public class MissionsFactory
    {
        private readonly Dictionary<MissionType, Func<MissionConfig, MissionBase>> _factories = new()
        {
            { MissionType.Manual, config => new ManualMission(config) },
        };

        public MissionBase Create(MissionConfig config)
        {
            if (!_factories.TryGetValue(config.Type, out var factory))
            {
                throw new ArgumentOutOfRangeException($"No factory registered for mission type {config.Type}");
            }
            return factory(config);
        }
    }
}
