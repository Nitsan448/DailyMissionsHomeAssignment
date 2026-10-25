using System;
using UnityEngine;

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

        public void Collect()
        {
            if (State != EMissionState.Completed)
            {
                Debug.LogWarning("Tried to collect an uncompleted mission");
                return;
            }
            
            UpdateState(EMissionState.Collected);
        }

        protected void UpdateState(EMissionState newState)
        {
            State = newState;
            StateUpdated?.Invoke(this);
        }
    }
}