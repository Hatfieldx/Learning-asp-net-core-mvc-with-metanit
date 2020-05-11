namespace HelloApp2.services
{
    public interface ITimer
    {
        string Time { get; }

        string GetConfigs(params string[] keys);
    }
}
