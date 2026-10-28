namespace Core.Tests.Utilities
{
    public static class ReflectionUtilities
    {
        // Reaches non-public setters, e.g. Unity-serialized config properties declared as { get; private set; }.
        public static void SetProperty(object target, string propertyName, object value)
        {
            target.GetType().GetProperty(propertyName).SetValue(target, value);
        }
    }
}
