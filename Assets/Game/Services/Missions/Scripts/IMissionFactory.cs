using Game.Services.Missions.Scripts.Base;
using Game.Services.Missions.Scripts.Config;

namespace Game.Services.Missions.Scripts
{
    public interface IMissionFactory
    {
        MissionType Type { get; }
        MissionBase Create(MissionConfig config);
    }
}
