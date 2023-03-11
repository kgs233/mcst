using System.Linq.Expressions;
using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;

namespace mcst
{
    /// <summary>
    /// Main fun and read Command
    /// </summary>
    class ProgramMain
    {
        static async Task Main(string[] args)
        {
            RootCommand rootCommand = new("Mc Server Tools - A powerful tools for Mincreaft Server");
            rootCommand.AddCommand(InitSubCommRun());
            Command subCommPackage = new Command("package", "Server package Manager");
            Command subCommSettings = new Command("settings", "Mcst Sttings");
            await rootCommand.InvokeAsync(args);
        }
        
        
        private static Command InitSubCommRun()
        {
            Command subCommRun = new Command("run", "Start Server");
            Argument<string> RunArgumentName = new(name: "name",
                                            description: "Starts the server with the specified name");
            Option<string> RunOptConfig = new(name: "--config",
                                              description: "Choose config file");
            Option<string> RunOptJre = new(name: "--jre",
                                           description: "Choose using JRE(Absolute Path)");
            Option<string> RunOptMaxMem = new(name: "--maxMem",
                                              description: "Set the maximum memory usage");
            Option<string> RunOptMinMem = new(name: "--minMem",
                                              description: "Set the minimum memory usage");
            Option<string> RunOptCoreName = new(name: "--coreName",
                                                   description: "Set Server Core Name");
            Option<bool> RunOptUseGUI = new(name: "UseGUI",
                                            description: "Use GUI(dot't add nogui parmeter)");
            Option<bool> RunOptDisDefJVMPare = new(name: "--DisDefJVMPare",
                                                   description: "Disable default JVM parameter");
            Option<string> RunOptJVMPara = new(name: "--JVMPara",
                                               description: "add custom JVM parameter");
            subCommRun.AddArgument(RunArgumentName);
            subCommRun.AddOption(RunOptConfig);
            subCommRun.AddOption(RunOptJre);
            subCommRun.AddOption(RunOptMaxMem);
            subCommRun.AddOption(RunOptMinMem);
            subCommRun.AddOption(RunOptCoreName);
            subCommRun.AddOption(RunOptUseGUI);
            subCommRun.AddOption(RunOptDisDefJVMPare);
            subCommRun.AddOption(RunOptJVMPara);
            subCommRun.SetHandler((context) => 
                                {
                                    ParseResult parseResult = context.ParseResult;
                                    ServerRun.ServerStart(new()
                                    {
                                        Name = parseResult.GetValueForArgument(RunArgumentName),
                                        Config = parseResult.GetValueForOption(RunOptConfig),
                                        Jre = parseResult.GetValueForOption(RunOptJre),
                                        MaxMem = parseResult.GetValueForOption(RunOptMaxMem),
                                        MinMem = parseResult.GetValueForOption(RunOptMinMem),
                                        CoreName = parseResult.GetValueForOption(RunOptCoreName),
                                        UseGUI = parseResult.GetValueForOption(RunOptUseGUI),
                                        DisDefJVMPare = parseResult.GetValueForOption(RunOptDisDefJVMPare),
                                        JVMPara = parseResult.GetValueForOption(RunOptJVMPara)
                                    });
                                });
            return subCommRun;
        }

    private static Command InitSubCommInstall()
        {
            Command subCommInstall = new Command("install", "Install new Server Core");
            return subCommInstall;
        }

        private static Command InitSubCommConfig()
        {
            Command subCommConfig = new Command("config", "");
            return subCommConfig;
        }
    }
}