using Game.Services.Missions.Scripts.Config;
using Game.Services.Missions.Scripts.Enums;

namespace Game.Services.Missions.Scripts.Factory
{
    public interface IMissionFactory
    {
        EMissionType Type { get; }
        MissionBase Create(MissionConfig config);
    }
}
