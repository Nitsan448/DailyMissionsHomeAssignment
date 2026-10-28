using Game.Services.DailyMissions.Scripts.Service;
using Game.Services.Missions;
using Game.Services.Missions.Scripts;
using Game.Services.Missions.Scripts.Base;
using Game.Services.Missions.Scripts.Config;
using VContainer;

namespace Game.Services.DailyMissions.Scripts.MissionImplementations
{
    //Generated with AI Assistance
    public class DailyMissionsStreakMissionFactory : IMissionFactory
    {
        public MissionType Type => MissionType.DailyMissionsStreak;

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
