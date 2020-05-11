using Microsoft.AspNetCore.Mvc;
using System;
using ViewComponentEDU.Models;

namespace ViewComponentEDU.Components
{
    public class Timer : ViewComponent
    {
        public string Invoke(bool fullTime = true, User user = null) => 
            $"Current time is {DateTime.Now.ToString((fullTime ? "HH" : "hh") + ":mm:ss")} \n User {user?.Name} age: {user?.Age}"; 
        
    }
}
