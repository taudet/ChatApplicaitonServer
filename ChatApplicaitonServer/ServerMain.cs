﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplicaitonServer
{
    internal class ServerMain
    {
        static void Main(string[] args)
        {
            ChatListener listener = new ChatListener();
            listener.StartListener();
        }
    }
}
