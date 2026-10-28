using Game.Missions.Config;

namespace Game.Missions.Typed
{
    public class ManualMission : TypedMissionBase
    {
        public ManualMission(TypedMissionConfig config) : base(config)
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