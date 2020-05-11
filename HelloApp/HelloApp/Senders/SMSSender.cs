using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloApp
{
    public class SMSSender : IMessageSender
    {
        public string Send()
        {
            return "sms sender";
        }
    }
}
