using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloApp
{
    public class EmailSender : IMessageSender
    {
        
        public string Send()
        {
            return "Email send";
        }
        
        public EmailSender()
        {
            
        }
    }
}
