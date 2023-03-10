using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mst
{
    public class ServerRun
    {
        private struct StartConfig
        {
            public string ServerName;
            public string CoreName;
            public string Jre;
            public string JreParm;
        }

        public struct CommandOption
        {
            public string Name;
            public string ?Config;
            public string ?Jre;
            public string ?MaxMem;
            public string ?MinMem;
            public string ?CoreName;
            public bool DisDefJVMPare;
            public bool UseGUI;
            public string ?JVMPara;
        }

        private static StartConfig GetStartConfig(CommandOption commandOption)
        {
            StartConfig config = new();
            config.ServerName = commandOption.Name;
            if(commandOption.Jre is null)
            {
                config.Jre =  MstConfig.DefaultJre;
            }
            else
            {
                config.Jre = commandOption.Jre;
            }
            
            if(commandOption.DisDefJVMPare)
            {
                if(commandOption.JVMPara is null)
                    Console.WriteLine("Error:You must to set JVM parameter or enable default parameter");
            }
            else
            {
                config.JreParm = MstConfig.DefaultJVMPrameper + commandOption.JVMPara;
            }
            return config;
        }

        public static void ServerStart(CommandOption commandOption)
        {
            GetStartConfig(commandOption);
        }
    }
}