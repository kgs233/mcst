using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mcst
{
    public static class ToolFun
    {
        public static void ErrorExit(string ErrorMessage)
        {
            Console.WriteLine(ErrorMessage);
            Environment.Exit(1);
        }
    }
}