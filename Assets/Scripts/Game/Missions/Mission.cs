namespace Game.Game.Missions
{
    public class Mission
    {
        public MissionConfig Config { get; private set; }
        public EMissionState State { get; private set; }
    }
}