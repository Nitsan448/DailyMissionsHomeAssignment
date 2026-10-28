using Game.Services.DailyMissions.Scripts.Service;
using Game.Services.Missions;
using Game.Services.Missions.Scripts;
using Game.Services.Missions.Scripts.Config;
using Game.Services.Missions.Scripts.Enums;
using Game.Services.Missions.Scripts.Factory;
using VContainer;

namespace Game.Services.DailyMissions.Scripts.MissionImplementations
{
    //Generated with AI Assistance
    public class DailyMissionsStreakMissionFactory : IMissionFactory
    {
        public EMissionType Type => EMissionType.DailyMissionsStreak;

        private readonly IObjectResolver _resolver;

        public DailyMissionsStreakMissionFactory(IObjectResolver resolver)
        {
            _resolver = resolver;
        }
        
        public MissionBase Create(MissionConfig config)
        {
            return new DailyMissionsStreakMission(config, _resolver.Resolve<IDailyMissionsService>());
        }
    }
}
