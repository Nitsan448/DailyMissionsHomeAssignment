using Game.Services.Missions.Scripts.Base;
using Game.Services.Missions.Scripts.Config;

namespace Game.Services.Missions.Scripts.Implementations
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
