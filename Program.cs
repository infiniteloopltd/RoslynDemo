using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace Roslyn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var scriptOptions = ScriptOptions.Default;
            var tWebClient = Type.GetType("System.Net.WebClient, System.Net");
            var asmWebClient = tWebClient?.Assembly;
            scriptOptions = scriptOptions.AddReferences(asmWebClient);
            var sample = File.ReadAllText("sample.txt");
            var result = CSharpScript.EvaluateAsync(sample, scriptOptions).Result;
            Console.WriteLine(result);
        }
    }
}