using Game.Missions.Base;
using Game.Missions.Config;

namespace Game.Missions.Implementations
{
    //Generated with AI Assistance
    public class ManualMissionFactory : IMissionFactory
    {
        public MissionType Type => MissionType.Manual;

        public MissionBase Create(MissionConfig config)
        {
            return new ManualMission(config);
        }
    }
}
