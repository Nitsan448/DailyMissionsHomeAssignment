using System;
using UnityEngine;

namespace Game.DailyMissions.Views
{
    [Serializable]
    public class DailyMissionViewSlot
    {
        [field:SerializeField] public DailyMissionView Prefab { get; private set; }
        [field:SerializeField] public Transform Container { get; private set; }
    }
}
