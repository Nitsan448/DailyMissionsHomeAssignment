using Game.Missions;
using Game.Missions.Config;
using UnityEngine;

namespace Game.DailyMissions.Config
{
    [CreateAssetMenu(fileName = "DailyMissionsConfig", menuName = "ScriptableObjects/DailyMissions")]
    public class DailyMissionsConfig : ScriptableObject
    {
        [field:SerializeField][field:Range(1, 7)] public int DailyMissionsCount { get; private set; }
        [field:SerializeField] public MissionConfig[] Missions { get; private set; }
        [field:SerializeField] public MissionConfig StreakMission { get; private set; }

        private void OnValidate()
        {
            if (DailyMissionsCount > Missions.Length)
            {
                Debug.LogWarning($"Daily missions count ({DailyMissionsCount}) is larger than the number of missions in the pool ({Missions.Length})", this);
            }
        }
    }
}