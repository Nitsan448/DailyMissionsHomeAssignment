using System;
using Game.Missions.Types;
using UnityEngine;

namespace Game.Missions
{
    public abstract class MissionBase
    {
        public event Action<MissionBase> StateUpdated;
        
        public MissionConfig Config { get; private set; }
        public EMissionState State { get; private set; } = EMissionState.InProgress;
        
        public abstract MissionType MissionType { get; }

        protected MissionBase(MissionConfig config)
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
            if (State == newState)
            {
                return;
            }
            
            State = newState;
            StateUpdated?.Invoke(this);
        }
    }
}