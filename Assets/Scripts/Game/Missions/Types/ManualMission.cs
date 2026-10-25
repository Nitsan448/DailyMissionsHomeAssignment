namespace Game.Missions.Types
{
    public class ManualMission : MissionBase
    {
        public override MissionType MissionType => MissionType.Manual;
        public ManualMission(MissionConfig config) : base(config)
        {
            
        }

        public void Complete()
        {
            UpdateState(EMissionState.Completed);
        }

    }
}