using Game.Missions.Base;
using Game.Missions.Config;

namespace Game.Missions
{
    public interface IMissionFactory
    {
        MissionType Type { get; }
        MissionBase Create(MissionConfig config);
    }
}
