using Game.Missions;
using UnityEngine;

namespace Game.DailyMissions.Config
{
    [CreateAssetMenu(fileName = "DailyMissionsConfig", menuName = "ScriptableObjects/DailyMissions")]
    public class DailyMissionsConfig : ScriptableObject
    {
        [field:SerializeField][field:Range(0, 7)] public int DailyMissionsCount { get; private set; }
        [field:SerializeField] public MissionConfig[] Missions { get; private set; }
        [field:SerializeField] public MissionConfig StreakMission { get; private set; }
    }
}