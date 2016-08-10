﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Database_Access.BusinessObjects
{
    public class Command: BOBase
    {
        public string name;
        public string phrase;
        public Dictionary<string, string> commandArgs;
    }
}
