using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuartzApp.ViewComponents
{
    public class Timer : ViewComponent
    {
        public string Invoke()
        {
            return DateTime.Now.ToString();
        }
    }
}
