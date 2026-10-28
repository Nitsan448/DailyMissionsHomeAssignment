using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Game.Missions.Typed
{
    //Generated with AI Assistance
    public class TypedMissionsFactory
    {
        private readonly Dictionary<MissionType, Func<TypedMissionConfig, TypedMissionBase>> _creators = new()
        {
            { MissionType.Manual, config => new ManualMission(config) },
        };

        public TypedMissionBase Create(TypedMissionConfig config)
        {
            if (!_creators.TryGetValue(config.Type, out var create))
            {
                throw new ArgumentOutOfRangeException(nameof(config), config.Type, "No creator registered for mission type");
            }
            return create(config);
        }
    }
}
