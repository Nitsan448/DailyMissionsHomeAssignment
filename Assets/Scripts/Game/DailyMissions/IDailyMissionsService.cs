using System.Collections.Generic;
using Game.Game.Missions;

namespace Game.Game.DailyMissions
{
    public interface IDailyMissionsService
    {
        public Mission StreakMission { get; }
        public List<Mission> Missions { get; }
    }
}