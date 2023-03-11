using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mcst
{
    public class ServerRun
    {
        private struct StartConfig
        {
            public string ServerName;
            public string CoreName;
            public string Jre;
            public string JreParm;
            public string McParm;
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

        private static CommandOption ConfigFile;

        private static StartConfig GetStartConfig(CommandOption commandOption)
        {
            StartConfig config = new();
            config.ServerName = commandOption.Name;
            if(commandOption.Jre is null)
            {
                if(ConfigFile.Jre is null)
                {
                    config.Jre = MstConfig.DefaultJre;
                }
                else
                {
                    config.Jre = ConfigFile.Jre;
                }
            }
            else
            {
                config.Jre = commandOption.Jre;
            }
            
            if(commandOption.DisDefJVMPare)
            {
                if(commandOption.JVMPara is null)
                {
                    ToolFun.ErrorExit("Error:You must to set JVM parameter or enable default parameter");
                }
            }
            else
            {
                config.JreParm = MstConfig.DefaultJVMPrameper + commandOption.JVMPara;
            }

            if(commandOption.MaxMem is not null)
            {
                config.JreParm += commandOption.MaxMem;
            }
            else
            {
                if(ConfigFile.MaxMem is null)
                {
                    ToolFun.ErrorExit("Error: Don't have MaxMem");
                }
                else
                {
                    config.JreParm += ConfigFile.MaxMem;
                }
            }
            
            if(commandOption.MinMem is null)
            {
                if(ConfigFile.MinMem is null)
                {
                    ToolFun.ErrorExit("Error: Don't have MinMem");
                }
                else
                {
                    config.JreParm += ConfigFile.MinMem;
                }
            }
            else
            {
                config.JreParm += commandOption.MinMem;
            }

            if(!commandOption.UseGUI)
            {
                config.McParm += "nogui";
            }

            return config;
        }

        public static void ServerStart(CommandOption commandOption)
        {
            GetStartConfig(commandOption);
        }
    }
}