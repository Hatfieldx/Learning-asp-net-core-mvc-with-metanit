using System;
using System.Collections.Generic;
using System.Text;

namespace netapp
{
    public class ViberRequestModel
    {
        public string Receiver { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public int Min_api_version { get; set; } = 3;
    }
}


