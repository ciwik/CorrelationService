using System;
using Core;
using Core.Correlation;
using Newtonsoft.Json;

namespace DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Function function = Function.Create(x => Math.Sin(x), 0, 6, 0.01);
            string json = JsonConvert.SerializeObject(function, Formatting.Indented);
            Function function2 = JsonConvert.DeserializeObject<Function>(json);
            Console.ReadKey();
        }
    }
}
