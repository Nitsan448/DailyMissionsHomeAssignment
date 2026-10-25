namespace Game.Game.Missions.Types
{
    public class MockMission : MissionBase
    {
        public MockMission(MissionConfig config) : base(config)
        {
            
        }

        public void Complete()
        {
            UpdateState(EMissionState.Completed);
        }
    }
}