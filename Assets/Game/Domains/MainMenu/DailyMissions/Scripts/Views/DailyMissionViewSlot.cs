using System;
using Game.UI.Missions.Scripts.Views;
using UnityEngine;

namespace Game.Domains.MainMenu.DailyMissions.Views
{
    [Serializable]
    public class DailyMissionViewSlot
    {
        [field:SerializeField] public MissionView Prefab { get; private set; }
        [field:SerializeField] public Transform Container { get; private set; }
    }
}
