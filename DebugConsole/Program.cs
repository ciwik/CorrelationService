using System;
using Core;
using Newtonsoft.Json;
using ScriptInterpretation;

namespace DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var scriptCompilator = new ScriptCompiler();
            Function function = Function.Create(scriptCompilator.GetFunc("Sin(x)"), 0, 6, 0.01);
            string json = JsonConvert.SerializeObject(function, Formatting.Indented);
            Function function2 = JsonConvert.DeserializeObject<Function>(json);
            Console.ReadKey();
        }
    }
}
