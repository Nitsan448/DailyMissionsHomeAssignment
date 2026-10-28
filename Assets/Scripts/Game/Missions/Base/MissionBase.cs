using System;
using Game.Missions.Config;
using UnityEngine;

namespace Game.Missions.Base
{
    public abstract class MissionBase : IDisposable
    {
        public event Action<MissionBase> StateUpdated;
        
        public MissionConfig Config { get; private set; }
        public EMissionState State { get; private set; } = EMissionState.InProgress;

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

        public virtual void Dispose()
        {
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