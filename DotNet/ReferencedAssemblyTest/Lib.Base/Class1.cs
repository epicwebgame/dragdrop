using System;

namespace Lib.Base
{
    public class Class1
    {
        public void Do()
        {
            var s = new String('-', 20);

            Console.WriteLine($"{s}\n{GetType().FullName}.Do\n{s}\n");
        }
    }
}