using Game.Services.Missions.Scripts.Base;
using Game.Services.Missions.Scripts.Config;

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