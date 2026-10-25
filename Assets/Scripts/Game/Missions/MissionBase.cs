using System;

namespace Game.Game.Missions
{
    public class MissionBase
    {
        public event Action<MissionBase> StateUpdated;
        
        public MissionConfig Config { get; private set; }
        public EMissionState State { get; private set; } = EMissionState.InProgress;

        public MissionBase(MissionConfig config)
        {
            Config = config;
        }

        public void UpdateState(EMissionState newState)
        {
            State = newState;
            StateUpdated?.Invoke(this);
        }
    }
}