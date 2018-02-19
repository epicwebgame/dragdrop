using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DifferentSyncLockSameCriticalSection
{
    class Program
    {
        static void Main(string[] args)
        {
            var sathyaish = new Person { Name = "Sathyaish Chakravarthy" };
            var superman = new Person { Name = "Superman" };
            var tasks = new List<Task>();

            // Must not lock on string so I am using
            // an object of the Person class as a lock
            tasks.Add(Task.Run( () => { Proc1(sathyaish); } ));
            tasks.Add(Task.Run(() => { Proc1(superman); }));

            Task.WhenAll(tasks);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void Proc1(object state)
        {
            // Although this would be a very bad practice
            lock(state)
            {
                try
                {
                    Console.WriteLine((state.ToString()).Length);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
    
    class Person
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
