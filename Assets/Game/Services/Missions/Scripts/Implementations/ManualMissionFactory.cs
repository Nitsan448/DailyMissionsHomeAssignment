using Game.Services.Missions.Scripts.Config;
using Game.Services.Missions.Scripts.Enums;
using Game.Services.Missions.Scripts.Factory;

namespace Game.Services.Missions.Scripts.Implementations
{
    //Generated with AI Assistance
    public class ManualMissionFactory : IMissionFactory
    {
        public EMissionType Type => EMissionType.Manual;

        public MissionBase Create(MissionConfig config)
        {
            return new ManualMission(config);
        }
    }
}
