namespace Game.Missions.Typed
{
    public abstract class TypedMissionBase : MissionBase
    {
        public MissionType Type { get; }

        protected TypedMissionBase(TypedMissionConfig config) : base(config)
        {
            Type = config.Type;
        }
    }
}