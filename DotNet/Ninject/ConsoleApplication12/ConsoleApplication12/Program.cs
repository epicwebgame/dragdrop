using Ninject;
using Ninject.Parameters;
using System;
using System.IO;

namespace ConsoleApplication12
{
    class Program
    {
        static void Main(string[] args)
        {
            var k = new StandardKernel();

            // k.Bind<Gar>().ToSelf().WithConstructorArgument<FileInfo>(new FileInfo("C:\\Sathyaish\\temp\\InCode.txt"));
            // k.Bind<Gar>().ToConstructor(x => new Gar(x.Inject<Har>(), new FileInfo("C:\\Sathyaish")));
            // var obj = k.Get<Gar>();

            //var obj = k.Get<Gar>("movies", new ConstructorArgument("f", new FileInfo("C:\\Sathyaish\\temp.Movies.txt")));

            var obj = k.Get<Gar>(new ConstructorArgument("f", new FileInfo("C:\\Sathyaish\\temp.Movies.txt")));

            Console.WriteLine(obj.GetType().Name);

            Console.ReadKey();
        }
    }

    class Foo
    {
        public Foo(Bar b)
        {

        }

        public Foo(Bar b, Gar g)
        {

        }
    }

    class Bar
    {
        public Bar()
        {

        }

        public Bar(Gar g)
        {

        }
    }

    class Gar
    {
        // [Inject]
        public Har OneMoreHar { get; set; }

        // [Inject]
        public Gar(Har h)
        {
            Console.WriteLine("Har");
        }

        public Gar(Har h, FileInfo f)
        {
            Console.WriteLine("Har and FileInfo. f.Name = " + f.Name);
        }
    }

    class Har { }
}
