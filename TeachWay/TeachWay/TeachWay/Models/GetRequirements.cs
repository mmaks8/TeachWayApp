﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TeachWay.Models
{
    public class GetRequirements
    {
        public string ID { get; set; }

        public string TITLE { get; set; }

        public string DESCRIPTION { get; set; }

    }
    public class User
    {
        public int ACCOUNT { get; set; }
        public int ISGRAD { get; set; }
    }
}
