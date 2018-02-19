using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace LinqProviderResearch
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder builder = new StringBuilder();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var asm in assemblies)
            {
                if (asm.GetName().Name.Contains("System.Core"))
                {
                    foreach (var type in asm.GetTypes())
                    {
                        if (type.Name.EndsWith("Proxy") && !type.Name.Contains("Expression"))
                        {
                            Console.WriteLine(type.Name);
                            builder.AppendLine(type.Name);
                        }
                    }
                }
            }

            File.WriteAllText("C:\\temp\\ProxiesOfExpressionsButWithoutTheWordExpressionInTheirName.txt", builder.ToString());

            Console.ReadKey();
        }
    }
}
