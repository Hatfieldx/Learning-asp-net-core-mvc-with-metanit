
namespace ConfigEdu
{
    public interface ITimer
    {
        string GetConfig(params string[] keys);

        string GetCurrentTime();
    }
}
