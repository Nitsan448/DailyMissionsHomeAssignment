using Game.Services.Missions.Scripts.Config;
using UnityEngine;

namespace Game.Services.DailyMissions.Scripts.Config
{
    [CreateAssetMenu(fileName = "DailyMissionsConfig", menuName = "ScriptableObjects/DailyMissions")]
    public class DailyMissionsConfig : ScriptableObject
    {
        [field:SerializeField] public MissionConfig[] AlwaysIncludedMissions { get; private set; }
        [field:SerializeField][field:Range(1, 7)] public int RandomizedDailyMissionsCount { get; private set; }
        [field:SerializeField] public MissionConfig[] MissionsPool { get; private set; }

        private void OnValidate()
        { 
            if (MissionsPool != null && RandomizedDailyMissionsCount > MissionsPool.Length)
            {
                Debug.LogWarning($"Daily missions count ({RandomizedDailyMissionsCount}) is larger than the number of missions in the pool ({MissionsPool.Length})", this);
            }
        }
    }
}