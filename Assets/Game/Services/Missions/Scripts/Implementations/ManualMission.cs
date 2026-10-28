using Game.Services.Missions.Scripts.Config;
using Game.Services.Missions.Scripts.Enums;

namespace Game.Services.Missions.Scripts.Implementations
{
    public class ManualMission : MissionBase
    {
        public ManualMission(MissionConfig config) : base(config)
        {
            
        }

        public void Complete()
        {
            if (State == EMissionState.InProgress)
            {
                UpdateState(EMissionState.Completed);
            }
        }

    }
}