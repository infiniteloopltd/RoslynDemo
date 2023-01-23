using System.Net;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace Roslyn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var scriptOptions = ScriptOptions.Default;
            var asmWebClient = typeof(WebClient).Assembly;
            scriptOptions = scriptOptions.AddReferences(asmWebClient);
            //scriptOptions = scriptOptions.AddImports("System.Net");
            var sample = File.ReadAllText("sample.txt");
            var result = CSharpScript.EvaluateAsync(sample, scriptOptions).Result;
            Console.WriteLine(result);
        }
    }
}