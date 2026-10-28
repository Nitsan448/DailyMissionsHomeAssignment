using Game.Missions.Base;
using Game.Missions.Config;

namespace Game.Missions.Implementations
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