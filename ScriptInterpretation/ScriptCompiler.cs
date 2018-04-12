using System;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace ScriptInterpretation
{
    public class ScriptCompiler
    {
        public Func<double, double> GetFunc(string funcText)
        {
            return CSharpScript.EvaluateAsync<Func<double, double>>($"x => {funcText}",
                ScriptOptions.Default.WithImports("System.Math")).Result;
        }
    }
}
