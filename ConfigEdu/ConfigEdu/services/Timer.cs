using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;

namespace ConfigEdu.services
{
    public class Timer : ITimer
    {
        IConfiguration _configuration;
        Order _order;

        public string GetConfig(params string[] keys)
        {
            return GetMultiStringConfig(keys);  
        }

        private string GetMultiStringConfig(string[] keys)
        {
            Order order = new Order();

            _configuration.Bind(order); 
            
            string result = "";

            foreach (string key in keys)
            {
                result += $"! {key} = {_configuration[key]} ---> \n";
            }


            string parse = GetParamsFromSections(_configuration);

            return parse;

        }

        private string GetParamsFromSections(IConfiguration configuration)
        {
            string result = "";
            
            foreach (var item in configuration.GetChildren())
            {
                if (item.Value == null)
                {
                    result += $"\n {item.Key}:";
                    result += GetParamsFromSections(item);
                }
                else
                    result += $"\n {item.Key} = {item.Value}";
            }
            return result;
        }

        public string GetCurrentTime()
        {
            return DateTime.Now.ToString("hh:mm:ss"); ;
        }

        public Timer(IConfiguration configuration, IOptions<Order> options)
        {
            _configuration = configuration;
            _order = options.Value;
           
        }
    }
}
