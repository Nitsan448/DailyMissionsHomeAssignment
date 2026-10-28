using Game.DailyMissions.Service;
using Game.Missions;
using Game.Missions.Base;
using Game.Missions.Config;
using VContainer;

namespace Game.DailyMissions.MissionImplementations
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
