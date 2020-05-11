using System;

namespace Views.Services
{
    public class Timer : ITimer
    {
        public string GetCurrentTime()
        {
            return DateTime.Now.ToLongDateString();
        }
    }
}
