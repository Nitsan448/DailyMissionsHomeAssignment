namespace Game.Game.DailyMissions
{
    public class DailyMissionsService : IDailyMissionsService
    {
        public DailyMissionsConfig DailyMissionsConfig { get; private set; }
        
        public DailyMissionsService(DailyMissionsConfig config)
        {
            DailyMissionsConfig = config;
        }
    }
}