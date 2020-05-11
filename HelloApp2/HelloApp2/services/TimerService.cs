using Microsoft.Extensions.Configuration;
using System;

namespace HelloApp2.services
{
    public class TimerService: ITimer
    {
        string _time;
        IConfiguration _config;
        
        public string Time { get=>_time; }

        public TimerService()
        {
            _time = DateTime.Now.ToString("hh:mm:ss");            
        }

        public string GetConfigs(params string[] keys)
        {
            string res = "";
            
            foreach (string item in keys)
            {
                res += "\n" + item + " = " + _config[item];
            }

            return res;
        }
        public override string ToString()
        {
            return Time + " realy current time!!))";
        }
        public TimerService(IConfiguration configuration)
        {
            _config = configuration;     
        }
    }
}
