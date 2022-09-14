using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal static partial class Program
{
    static readonly Dictionary<string, string> answer = new();
    private static void Parse(string[] args)
    {
        for (int i = 0; i < args.Length; i++)
        {
            if (args.Length - 1 < i + 1) continue;
            answer[args[i]] = args[i + 1];
            i++;
        }
    }
    private static string Obtain(string key)
    {
        return answer.ContainsKey(key) ? answer[key] : "";
    }
}
